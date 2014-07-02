using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GTAV
{
    class CSC
    {
        private EndianIO io;
        private byte[] buffer;

        public header_t header;
        public dataInfo_t dataInfo;

        public string scriptName;
        public uint[] Natives;

        public byte[] codePageData;
        public string[] scriptStrings;

        public int[] StringPages;
        public int[] CodePages;

        public CSC(string path)
        {
            buffer = File.ReadAllBytes(path);
        }

        public CSC(byte[] _buffer)
        {
            buffer = _buffer;
        }

        public CSC(CSC csc)
        {
            //idk yet...
        }

        private bool checkVersion()
        {
            if (io.In.ReadUInt32() == 0x52534337)  //RSC7
                return true;
            return false;
        }

        public void Read()
        {
            io = new EndianIO(buffer, EndianType.BigEndian, true);

            if (!checkVersion())
                return;

            io.Position = 0;

            //read header
            header.magic = io.In.ReadUInt32();
            header.version = io.In.ReadInt32();

            io.Position += 8; //skip to data start.

            //read start of data info..
            io.Position += 8; //skip past unk0 and hash...
            dataInfo.codeBlockOffset = getOffset(io.In.ReadInt32());
            dataInfo.globalsVersion = io.In.ReadInt32();

            //counts
            dataInfo.codeLength = io.In.ReadInt32();
            dataInfo.paramsCount = io.In.ReadInt32();
            dataInfo.staticsCount = io.In.ReadInt32();
            dataInfo.globalsCount = io.In.ReadInt32();
            dataInfo.nativesCount = io.In.ReadInt32();

            //offsets
            dataInfo.staticsOffset = getOffset(io.In.ReadInt32());
            dataInfo.globalsOffset = getOffset(io.In.ReadInt32());
            dataInfo.nativesOffset = getOffset(io.In.ReadInt32());

            io.Position += 16;

            dataInfo.scriptNameOffset = getOffset(io.In.ReadInt32());
            dataInfo.stringBlockOffset = getOffset(io.In.ReadInt32());
            dataInfo.stringSize = io.In.ReadInt32();

            //Getting the code pages
            io.Position = dataInfo.codeBlockOffset;
            int pageCount = getPageCount(dataInfo.codeLength);
            CodePages = new int[pageCount];
            for (int i = 0; i < pageCount; i++)
                CodePages[i] = getOffset(io.In.ReadInt32());

            //Getting the string pages
            io.Position = dataInfo.stringBlockOffset;
            pageCount = getPageCount(dataInfo.stringSize);
            StringPages = new int[pageCount];
            for (int i = 0; i < pageCount; i++)
                StringPages[i] = getOffset(io.In.ReadInt32());

            //Getting the natives
            io.Position = dataInfo.nativesOffset;
            Natives = new uint[dataInfo.nativesCount];
            for (int i = 0; i < dataInfo.nativesCount; i++)
                Natives[i] = io.In.ReadUInt32();

            //Getting the script name
            io.Position = dataInfo.scriptNameOffset;
            scriptName = io.In.ReadCString();

            //get string pages strings..
            scriptStrings = ExtractStringPage(0);

            //get first code page
            codePageData = ExtractCodePage(0);

            interpretCSC();

        }

        private void interpretCSC()
        {
            //to do: interpret.
        }

        private int getOffset(int n)
        {
            return (n & 0xFFFFFF) + 0x10;
        }

        private int getPageCount(int n)
        {
            return ( n + 0x3FFF) >> 0xE;
        }

        private int getPageLen(int numPages, int pagesLen, int pg)
        {
            return (pg == numPages) ? (pagesLen % 0x4000) : 0x4000;
        }

        private string[] ExtractStringPage(int page)
        {
            int pageLen = getPageLen((StringPages.Length - 1), dataInfo.stringSize, page);
            io.Position = StringPages[page];

            int len = 0;
            List<string> stringsFound = new List<string>();
            while (len < pageLen)
            {
                string str = io.In.ReadCString();

                if (str != "")
                    stringsFound.Add(str);

                len += str.Length + 1;
            }
            return stringsFound.ToArray();
        }

        public byte[] ExtractCodePage(int page)
        {
            int pageLen = getPageLen(CodePages.Length - 1, dataInfo.codeLength, page);
            io.Position = CodePages[page];
            return io.In.ReadBytes(pageLen);
        }

        public struct header_t
        {
            public uint magic; //RSC7
            public int version; //rage version
        }

        public struct dataInfo_t
        {
            public int hash;
            public int unk0;
            public int codeBlockOffset;
            public int globalsVersion;
            public int codeLength;
            public int paramsCount;
            public int staticsCount;
            public int globalsCount;
            public int nativesCount;
            public int staticsOffset;
            public int globalsOffset;
            public int nativesOffset;
            public int unk1;
            public int unk2;
            public int unk3;
            public int unk4;
            public int scriptNameOffset;
            public int stringBlockOffset;
            public int stringSize;
            public int unk5;
        }
    }
}
