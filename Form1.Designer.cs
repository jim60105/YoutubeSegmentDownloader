namespace YoutubeSegmentDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label_checking_ytdlp = new Label();
            label2 = new Label();
            label1 = new Label();
            label_checking_ffmpeg = new Label();
            tableLayoutPanel_main = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox_outputDirectory = new TextBox();
            button_folder = new Button();
            label8 = new Label();
            label3 = new Label();
            textBox_youtube = new TextBox();
            checkBox_segment = new CheckBox();
            tableLayoutPanel_segment = new TableLayoutPanel();
            textBox_end = new TextBox();
            label6 = new Label();
            textBox_start = new TextBox();
            label5 = new Label();
            button_start = new Button();
            panel_download = new Panel();
            richTextBox2 = new RichTextBox();
            richTextBoxLogControl1 = new Serilog.Sinks.WinForms.RichTextBoxLogControl();
            checkBox_logVerbose = new CheckBox();
            panel_main = new Panel();
            hiddenlabel1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            comboBox_browser = new ComboBox();
            groupBox3 = new GroupBox();
            textBox_format = new TextBox();
            groupBox1 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label4 = new Label();
            button_redownloadDependencies = new Button();
            richTextBox1 = new RichTextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            tableLayoutPanel_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel_segment.SuspendLayout();
            panel_download.SuspendLayout();
            panel_main.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(label_checking_ytdlp);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label_checking_ffmpeg);
            panel1.Name = "panel1";
            // 
            // label_checking_ytdlp
            // 
            resources.ApplyResources(label_checking_ytdlp, "label_checking_ytdlp");
            label_checking_ytdlp.Name = "label_checking_ytdlp";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label_checking_ffmpeg
            // 
            resources.ApplyResources(label_checking_ffmpeg, "label_checking_ffmpeg");
            label_checking_ffmpeg.Name = "label_checking_ffmpeg";
            // 
            // tableLayoutPanel_main
            // 
            resources.ApplyResources(tableLayoutPanel_main, "tableLayoutPanel_main");
            tableLayoutPanel_main.Controls.Add(tableLayoutPanel1, 1, 0);
            tableLayoutPanel_main.Controls.Add(label8, 0, 0);
            tableLayoutPanel_main.Controls.Add(label3, 0, 1);
            tableLayoutPanel_main.Controls.Add(textBox_youtube, 1, 1);
            tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(textBox_outputDirectory, 0, 0);
            tableLayoutPanel1.Controls.Add(button_folder, 1, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // textBox_outputDirectory
            // 
            resources.ApplyResources(textBox_outputDirectory, "textBox_outputDirectory");
            textBox_outputDirectory.Name = "textBox_outputDirectory";
            textBox_outputDirectory.TabStop = false;
            toolTip1.SetToolTip(textBox_outputDirectory, resources.GetString("textBox_outputDirectory.ToolTip"));
            textBox_outputDirectory.DoubleClick += button_folder_Click;
            textBox_outputDirectory.KeyDown += enter_KeyDown;
            // 
            // button_folder
            // 
            resources.ApplyResources(button_folder, "button_folder");
            button_folder.Name = "button_folder";
            button_folder.TabStop = false;
            button_folder.UseMnemonic = false;
            button_folder.UseVisualStyleBackColor = true;
            button_folder.Click += button_folder_Click;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBox_youtube
            // 
            resources.ApplyResources(textBox_youtube, "textBox_youtube");
            textBox_youtube.Name = "textBox_youtube";
            toolTip1.SetToolTip(textBox_youtube, resources.GetString("textBox_youtube.ToolTip"));
            textBox_youtube.TextChanged += textBox_youtube_TextChanged;
            textBox_youtube.KeyDown += enter_KeyDown;
            // 
            // checkBox_segment
            // 
            resources.ApplyResources(checkBox_segment, "checkBox_segment");
            checkBox_segment.Checked = true;
            checkBox_segment.CheckState = CheckState.Checked;
            checkBox_segment.Name = "checkBox_segment";
            toolTip1.SetToolTip(checkBox_segment, resources.GetString("checkBox_segment.ToolTip"));
            checkBox_segment.UseVisualStyleBackColor = true;
            checkBox_segment.CheckedChanged += checkBox_segment_CheckedChanged;
            checkBox_segment.KeyDown += enter_KeyDown;
            // 
            // tableLayoutPanel_segment
            // 
            resources.ApplyResources(tableLayoutPanel_segment, "tableLayoutPanel_segment");
            tableLayoutPanel_segment.Controls.Add(textBox_end, 1, 1);
            tableLayoutPanel_segment.Controls.Add(label6, 0, 0);
            tableLayoutPanel_segment.Controls.Add(textBox_start, 0, 1);
            tableLayoutPanel_segment.Controls.Add(label5, 1, 0);
            tableLayoutPanel_segment.Name = "tableLayoutPanel_segment";
            // 
            // textBox_end
            // 
            resources.ApplyResources(textBox_end, "textBox_end");
            textBox_end.Name = "textBox_end";
            toolTip1.SetToolTip(textBox_end, resources.GetString("textBox_end.ToolTip"));
            textBox_end.KeyDown += enter_KeyDown;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // textBox_start
            // 
            resources.ApplyResources(textBox_start, "textBox_start");
            textBox_start.Name = "textBox_start";
            toolTip1.SetToolTip(textBox_start, resources.GetString("textBox_start.ToolTip"));
            textBox_start.KeyDown += enter_KeyDown;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // button_start
            // 
            resources.ApplyResources(button_start, "button_start");
            button_start.Name = "button_start";
            toolTip1.SetToolTip(button_start, resources.GetString("button_start.ToolTip"));
            button_start.UseMnemonic = false;
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // panel_download
            // 
            resources.ApplyResources(panel_download, "panel_download");
            panel_download.BackColor = SystemColors.Control;
            panel_download.Controls.Add(richTextBox2);
            panel_download.Controls.Add(panel1);
            panel_download.Name = "panel_download";
            // 
            // richTextBox2
            // 
            resources.ApplyResources(richTextBox2, "richTextBox2");
            richTextBox2.BackColor = SystemColors.Control;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.TabStop = false;
            richTextBox2.LinkClicked += richTextBox_LinkClicked;
            // 
            // richTextBoxLogControl1
            // 
            resources.ApplyResources(richTextBoxLogControl1, "richTextBoxLogControl1");
            richTextBoxLogControl1.ForContext = "";
            richTextBoxLogControl1.Name = "richTextBoxLogControl1";
            richTextBoxLogControl1.ReadOnly = true;
            richTextBoxLogControl1.TabStop = false;
            // 
            // checkBox_logVerbose
            // 
            resources.ApplyResources(checkBox_logVerbose, "checkBox_logVerbose");
            checkBox_logVerbose.Name = "checkBox_logVerbose";
            checkBox_logVerbose.TabStop = false;
            toolTip1.SetToolTip(checkBox_logVerbose, resources.GetString("checkBox_logVerbose.ToolTip"));
            checkBox_logVerbose.UseVisualStyleBackColor = true;
            checkBox_logVerbose.CheckedChanged += checkBox_logVerbose_CheckedChanged;
            // 
            // panel_main
            // 
            panel_main.Controls.Add(hiddenlabel1);
            panel_main.Controls.Add(tableLayoutPanel2);
            panel_main.Controls.Add(button_redownloadDependencies);
            panel_main.Controls.Add(checkBox_logVerbose);
            panel_main.Controls.Add(tableLayoutPanel_main);
            panel_main.Controls.Add(richTextBoxLogControl1);
            panel_main.Controls.Add(richTextBox1);
            resources.ApplyResources(panel_main, "panel_main");
            panel_main.Name = "panel_main";
            // 
            // hiddenlabel1
            // 
            resources.ApplyResources(hiddenlabel1, "hiddenlabel1");
            hiddenlabel1.Name = "hiddenlabel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(button_start, 2, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(tableLayoutPanel3, "tableLayoutPanel3");
            tableLayoutPanel3.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel3.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(comboBox_browser);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip1.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // comboBox_browser
            // 
            resources.ApplyResources(comboBox_browser, "comboBox_browser");
            comboBox_browser.DropDownHeight = 110;
            comboBox_browser.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_browser.FormattingEnabled = true;
            comboBox_browser.Items.AddRange(new object[] { resources.GetString("comboBox_browser.Items"), resources.GetString("comboBox_browser.Items1"), resources.GetString("comboBox_browser.Items2"), resources.GetString("comboBox_browser.Items3"), resources.GetString("comboBox_browser.Items4"), resources.GetString("comboBox_browser.Items5"), resources.GetString("comboBox_browser.Items6"), resources.GetString("comboBox_browser.Items7"), resources.GetString("comboBox_browser.Items8") });
            comboBox_browser.Name = "comboBox_browser";
            comboBox_browser.Sorted = true;
            comboBox_browser.TabStop = false;
            toolTip1.SetToolTip(comboBox_browser, resources.GetString("comboBox_browser.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(textBox_format);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip1.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // textBox_format
            // 
            resources.ApplyResources(textBox_format, "textBox_format");
            textBox_format.Name = "textBox_format";
            textBox_format.TabStop = false;
            toolTip1.SetToolTip(textBox_format, resources.GetString("textBox_format.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(tableLayoutPanel4);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(tableLayoutPanel4, "tableLayoutPanel4");
            tableLayoutPanel4.Controls.Add(tableLayoutPanel_segment, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(tableLayoutPanel5, "tableLayoutPanel5");
            tableLayoutPanel5.Controls.Add(label4, 0, 0);
            tableLayoutPanel5.Controls.Add(checkBox_segment, 1, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // button_redownloadDependencies
            // 
            resources.ApplyResources(button_redownloadDependencies, "button_redownloadDependencies");
            button_redownloadDependencies.Name = "button_redownloadDependencies";
            button_redownloadDependencies.TabStop = false;
            toolTip1.SetToolTip(button_redownloadDependencies, resources.GetString("button_redownloadDependencies.ToolTip"));
            button_redownloadDependencies.UseVisualStyleBackColor = true;
            button_redownloadDependencies.Click += button_redownloadDependencies_Click;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(richTextBox1, "richTextBox1");
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.TabStop = false;
            toolTip1.SetToolTip(richTextBox1, resources.GetString("richTextBox1.ToolTip"));
            richTextBox1.LinkClicked += richTextBox_LinkClicked;
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(folderBrowserDialog1, "folderBrowserDialog1");
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_download);
            Controls.Add(panel_main);
            Name = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel_main.ResumeLayout(false);
            tableLayoutPanel_main.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel_segment.ResumeLayout(false);
            tableLayoutPanel_segment.PerformLayout();
            panel_download.ResumeLayout(false);
            panel_main.ResumeLayout(false);
            panel_main.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label_checking_ytdlp;
        private Label label2;
        private Label label1;
        private Label label_checking_ffmpeg;
        private TableLayoutPanel tableLayoutPanel_main;
        private Label label3;
        private CheckBox checkBox_segment;
        private TableLayoutPanel tableLayoutPanel_segment;
        private TextBox textBox_start;
        private Label label6;
        private Label label5;
        private TextBox textBox_end;
        private Label label8;
        private Button button_start;
        private Panel panel_download;
        private Serilog.Sinks.WinForms.RichTextBoxLogControl richTextBoxLogControl1;
        private CheckBox checkBox_logVerbose;
        private Panel panel_main;
        private FolderBrowserDialog folderBrowserDialog1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button button_redownloadDependencies;
        private ToolTip toolTip1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBox_browser;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox_outputDirectory;
        private Button button_folder;
        private TextBox textBox_youtube;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox textBox_format;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label4;
        private Label hiddenlabel1;
    }
}