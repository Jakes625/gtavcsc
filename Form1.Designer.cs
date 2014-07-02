namespace CSC_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcodeBox = new System.Windows.Forms.RichTextBox();
            this.nativesList = new System.Windows.Forms.ListBox();
            this.scriptStringsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.nativeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCSCToolStripMenuItem,
            this.saveCSCToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCSCToolStripMenuItem
            // 
            this.openCSCToolStripMenuItem.Name = "openCSCToolStripMenuItem";
            this.openCSCToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openCSCToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openCSCToolStripMenuItem.Text = "Open CSC";
            this.openCSCToolStripMenuItem.Click += new System.EventHandler(this.openCSCToolStripMenuItem_Click);
            // 
            // saveCSCToolStripMenuItem
            // 
            this.saveCSCToolStripMenuItem.Name = "saveCSCToolStripMenuItem";
            this.saveCSCToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveCSCToolStripMenuItem.Text = "Save CSC";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // opcodeBox
            // 
            this.opcodeBox.Location = new System.Drawing.Point(12, 53);
            this.opcodeBox.Name = "opcodeBox";
            this.opcodeBox.Size = new System.Drawing.Size(557, 304);
            this.opcodeBox.TabIndex = 1;
            this.opcodeBox.Text = "";
            // 
            // nativesList
            // 
            this.nativesList.FormattingEnabled = true;
            this.nativesList.Location = new System.Drawing.Point(575, 53);
            this.nativesList.Name = "nativesList";
            this.nativesList.Size = new System.Drawing.Size(169, 303);
            this.nativesList.TabIndex = 2;
            // 
            // scriptStringsList
            // 
            this.scriptStringsList.FormattingEnabled = true;
            this.scriptStringsList.Location = new System.Drawing.Point(750, 53);
            this.scriptStringsList.Name = "scriptStringsList";
            this.scriptStringsList.Size = new System.Drawing.Size(169, 303);
            this.scriptStringsList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "OP Codes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Natives";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(750, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Script Strings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nativeStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // nativeStatus
            // 
            this.nativeStatus.Image = global::CSC_Editor.Properties.Resources.loader;
            this.nativeStatus.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.nativeStatus.Name = "nativeStatus";
            this.nativeStatus.Size = new System.Drawing.Size(165, 17);
            this.nativeStatus.Text = "Please wait, getting natives";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 385);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scriptStringsList);
            this.Controls.Add(this.nativesList);
            this.Controls.Add(this.opcodeBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CSCEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCSCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCSCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox opcodeBox;
        private System.Windows.Forms.ListBox nativesList;
        private System.Windows.Forms.ListBox scriptStringsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel nativeStatus;
    }
}

