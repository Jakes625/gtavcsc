using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Net;

using GTAV;

namespace CSC_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Task task = GetNativesInit();
        }

        //native info..
        native[] natives;
        bool nativesLoaded = false;

        public struct native
        {
            public uint hash;
            public string name;
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openCSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a GTA V CSC File.";
            if (op.ShowDialog() == DialogResult.OK)
            {
                if (!nativesLoaded) //we need natives before we can open csc.
                    return;

                CSC ScriptFile = new CSC(op.FileName);
                ScriptFile.Read(); //read the file..

                opcodeBox.Text = "";
                nativesList.Items.Clear();
                scriptStringsList.Items.Clear();
                this.Text = "CSCEditor - " + ScriptFile.scriptName;

                for (int i = 0; i < ScriptFile.Natives.Length; i++)
                {
                    nativesList.Items.Add(getNativeName(ScriptFile.Natives[i],natives));
                }

                foreach(string scriptString in ScriptFile.scriptStrings)
                {
                    scriptStringsList.Items.Add(scriptString);
                }

                for (int i = 0; i < 500; i++)
                {
                    string code = "\t" + ScriptFile.codePageData[i].ToString("X");
                    switch (ScriptFile.codePageData[i])
                    {
                        case 0:
                            code = "\tnop";
                            break;

                        case 1:
                            code = "\tiadd";
                            break;

                        case 2:
                            code = "\tisub";
                            break;

                        case 3:
                            code = "\timul";
                            break;

                        case 4:
                            code = "\tidiv";
                            break;

                        case 5:
                            code = "\timod";
                            break;

                        case 6:
                            code = "\tiszero";
                            break;

                        case 7:
                            code = "\tineg";
                            break;

                        case 8:
                            code = "\ticompeq";
                            break;

                        case 45:
                            code = "\tnativeCall";
                            int argCount = ScriptFile.codePageData[i + 1];
                            int retCount = ScriptFile.codePageData[i + 2];

                            byte[] hash = new byte[4];
                            Buffer.BlockCopy(ScriptFile.codePageData, i + 3, hash, 0, 4);
                            Array.Reverse(hash);
                            uint n = BitConverter.ToUInt32(hash, 0);
                            code += ": " + getNativeName(n, natives);

                            break;

                        case 46:
                            code = "{";
                            break;

                        case 47:
                            code = "}";
                            break;
                    }
                    opcodeBox.Text += code + "\n";
                }

            }
            op.Dispose();
        }

        #region natives

        private Task GetNativesInit()
        {
            return Task.Run(() => GetNatives());
        }

        async Task GetNatives()
        {
            natives = GetNativeNames().ToArray();
            nativesLoaded = true;
            nativeStatus.Text = "Natives Loaded";
            nativeStatus.Image = null;
        }

        public string getNativeName(uint code, native[] natives)
        {
            for (int i = 0; i < natives.Length; i++)
            {
                if (natives[i].hash == code)
                    return natives[i].name;
            }
            return code.ToString();
        }

        public List<native> GetNativeNames()
        {
            List<native> natives = new List<native>();

            byte[] result = GetFileViaHttp(@"http://gta5hasher.glokon.org/raw/confirmed");
            string str = Encoding.UTF8.GetString(result);
            str = str.Replace("<pre>", "");
            str = str.Replace("</pre>", "");

            string[] strArr = str.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].StartsWith("//"))
                    continue;

                int split_index = strArr[i].IndexOf(':');

                native native;

                native.hash = Convert.ToUInt32(strArr[i].Substring(0, split_index));
                native.name = strArr[i].Substring(split_index + 1);

                natives.Add(native);

            }

            return natives;
        }

        public byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }

        #endregion
    }
}
