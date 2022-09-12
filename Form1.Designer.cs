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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_checking_ytdlp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_checking_ffmpeg = new System.Windows.Forms.Label();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_outputDirectory = new System.Windows.Forms.TextBox();
            this.button_folder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_youtube = new System.Windows.Forms.TextBox();
            this.checkBox_segment = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_segment = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_end = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.panel_download = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLogControl1 = new Serilog.Sinks.WinForms.RichTextBoxLogControl();
            this.checkBox_logVerbose = new System.Windows.Forms.CheckBox();
            this.panel_main = new System.Windows.Forms.Panel();
            this.hiddenlabel1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_browser = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_format = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.button_redownloadDependencies = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel_main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_segment.SuspendLayout();
            this.panel_download.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label_checking_ytdlp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_checking_ffmpeg);
            this.panel1.Name = "panel1";
            // 
            // label_checking_ytdlp
            // 
            resources.ApplyResources(this.label_checking_ytdlp, "label_checking_ytdlp");
            this.label_checking_ytdlp.Name = "label_checking_ytdlp";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label_checking_ffmpeg
            // 
            resources.ApplyResources(this.label_checking_ffmpeg, "label_checking_ffmpeg");
            this.label_checking_ffmpeg.Name = "label_checking_ffmpeg";
            // 
            // tableLayoutPanel_main
            // 
            resources.ApplyResources(this.tableLayoutPanel_main, "tableLayoutPanel_main");
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel_main.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel_main.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel_main.Controls.Add(this.textBox_youtube, 1, 1);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.textBox_outputDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_folder, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // textBox_outputDirectory
            // 
            resources.ApplyResources(this.textBox_outputDirectory, "textBox_outputDirectory");
            this.textBox_outputDirectory.Name = "textBox_outputDirectory";
            this.textBox_outputDirectory.TabStop = false;
            this.toolTip1.SetToolTip(this.textBox_outputDirectory, resources.GetString("textBox_outputDirectory.ToolTip"));
            this.textBox_outputDirectory.DoubleClick += new System.EventHandler(this.button_folder_Click);
            this.textBox_outputDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // button_folder
            // 
            resources.ApplyResources(this.button_folder, "button_folder");
            this.button_folder.Name = "button_folder";
            this.button_folder.TabStop = false;
            this.button_folder.UseMnemonic = false;
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBox_youtube
            // 
            resources.ApplyResources(this.textBox_youtube, "textBox_youtube");
            this.textBox_youtube.Name = "textBox_youtube";
            this.toolTip1.SetToolTip(this.textBox_youtube, resources.GetString("textBox_youtube.ToolTip"));
            this.textBox_youtube.TextChanged += new System.EventHandler(this.textBox_youtube_TextChanged);
            this.textBox_youtube.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // checkBox_segment
            // 
            resources.ApplyResources(this.checkBox_segment, "checkBox_segment");
            this.checkBox_segment.Checked = true;
            this.checkBox_segment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_segment.Name = "checkBox_segment";
            this.toolTip1.SetToolTip(this.checkBox_segment, resources.GetString("checkBox_segment.ToolTip"));
            this.checkBox_segment.UseVisualStyleBackColor = true;
            this.checkBox_segment.CheckedChanged += new System.EventHandler(this.checkBox_segment_CheckedChanged);
            this.checkBox_segment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // tableLayoutPanel_segment
            // 
            resources.ApplyResources(this.tableLayoutPanel_segment, "tableLayoutPanel_segment");
            this.tableLayoutPanel_segment.Controls.Add(this.textBox_end, 1, 1);
            this.tableLayoutPanel_segment.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel_segment.Controls.Add(this.textBox_start, 0, 1);
            this.tableLayoutPanel_segment.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel_segment.Name = "tableLayoutPanel_segment";
            // 
            // textBox_end
            // 
            resources.ApplyResources(this.textBox_end, "textBox_end");
            this.textBox_end.Name = "textBox_end";
            this.toolTip1.SetToolTip(this.textBox_end, resources.GetString("textBox_end.ToolTip"));
            this.textBox_end.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // textBox_start
            // 
            resources.ApplyResources(this.textBox_start, "textBox_start");
            this.textBox_start.Name = "textBox_start";
            this.toolTip1.SetToolTip(this.textBox_start, resources.GetString("textBox_start.ToolTip"));
            this.textBox_start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // button_start
            // 
            resources.ApplyResources(this.button_start, "button_start");
            this.button_start.Name = "button_start";
            this.toolTip1.SetToolTip(this.button_start, resources.GetString("button_start.ToolTip"));
            this.button_start.UseMnemonic = false;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // panel_download
            // 
            resources.ApplyResources(this.panel_download, "panel_download");
            this.panel_download.BackColor = System.Drawing.SystemColors.Control;
            this.panel_download.Controls.Add(this.richTextBox2);
            this.panel_download.Controls.Add(this.panel1);
            this.panel_download.Name = "panel_download";
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_LinkClicked);
            // 
            // richTextBoxLogControl1
            // 
            resources.ApplyResources(this.richTextBoxLogControl1, "richTextBoxLogControl1");
            this.richTextBoxLogControl1.ForContext = "";
            this.richTextBoxLogControl1.Name = "richTextBoxLogControl1";
            this.richTextBoxLogControl1.ReadOnly = true;
            this.richTextBoxLogControl1.TabStop = false;
            // 
            // checkBox_logVerbose
            // 
            resources.ApplyResources(this.checkBox_logVerbose, "checkBox_logVerbose");
            this.checkBox_logVerbose.Name = "checkBox_logVerbose";
            this.checkBox_logVerbose.TabStop = false;
            this.toolTip1.SetToolTip(this.checkBox_logVerbose, resources.GetString("checkBox_logVerbose.ToolTip"));
            this.checkBox_logVerbose.UseVisualStyleBackColor = true;
            this.checkBox_logVerbose.CheckedChanged += new System.EventHandler(this.checkBox_logVerbose_CheckedChanged);
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.hiddenlabel1);
            this.panel_main.Controls.Add(this.tableLayoutPanel2);
            this.panel_main.Controls.Add(this.button_redownloadDependencies);
            this.panel_main.Controls.Add(this.checkBox_logVerbose);
            this.panel_main.Controls.Add(this.tableLayoutPanel_main);
            this.panel_main.Controls.Add(this.richTextBoxLogControl1);
            this.panel_main.Controls.Add(this.richTextBox1);
            resources.ApplyResources(this.panel_main, "panel_main");
            this.panel_main.Name = "panel_main";
            // 
            // hiddenlabel1
            // 
            resources.ApplyResources(this.hiddenlabel1, "hiddenlabel1");
            this.hiddenlabel1.Name = "hiddenlabel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_start, 2, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.comboBox_browser);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // comboBox_browser
            // 
            resources.ApplyResources(this.comboBox_browser, "comboBox_browser");
            this.comboBox_browser.DropDownHeight = 110;
            this.comboBox_browser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_browser.FormattingEnabled = true;
            this.comboBox_browser.Items.AddRange(new object[] {
            resources.GetString("comboBox_browser.Items"),
            resources.GetString("comboBox_browser.Items1"),
            resources.GetString("comboBox_browser.Items2"),
            resources.GetString("comboBox_browser.Items3"),
            resources.GetString("comboBox_browser.Items4"),
            resources.GetString("comboBox_browser.Items5"),
            resources.GetString("comboBox_browser.Items6"),
            resources.GetString("comboBox_browser.Items7"),
            resources.GetString("comboBox_browser.Items8")});
            this.comboBox_browser.Name = "comboBox_browser";
            this.comboBox_browser.Sorted = true;
            this.comboBox_browser.TabStop = false;
            this.toolTip1.SetToolTip(this.comboBox_browser, resources.GetString("comboBox_browser.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.textBox_format);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // textBox_format
            // 
            resources.ApplyResources(this.textBox_format, "textBox_format");
            this.textBox_format.Name = "textBox_format";
            this.textBox_format.TabStop = false;
            this.toolTip1.SetToolTip(this.textBox_format, resources.GetString("textBox_format.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel_segment, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.checkBox_segment, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button_redownloadDependencies
            // 
            resources.ApplyResources(this.button_redownloadDependencies, "button_redownloadDependencies");
            this.button_redownloadDependencies.Name = "button_redownloadDependencies";
            this.button_redownloadDependencies.TabStop = false;
            this.toolTip1.SetToolTip(this.button_redownloadDependencies, resources.GetString("button_redownloadDependencies.ToolTip"));
            this.button_redownloadDependencies.UseVisualStyleBackColor = true;
            this.button_redownloadDependencies.Click += new System.EventHandler(this.button_redownloadDependencies_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.richTextBox1, resources.GetString("richTextBox1.ToolTip"));
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_LinkClicked);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_download);
            this.Controls.Add(this.panel_main);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_segment.ResumeLayout(false);
            this.tableLayoutPanel_segment.PerformLayout();
            this.panel_download.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

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