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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_checking_ytdlp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_checking_ffmpeg = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_youtube = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_segment = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_segment = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_end = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel_download = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_segment.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_download.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label_checking_ytdlp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_checking_ffmpeg);
            this.panel1.Location = new System.Drawing.Point(200, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 100);
            this.panel1.TabIndex = 0;
            // 
            // label_checking_ytdlp
            // 
            this.label_checking_ytdlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_checking_ytdlp.AutoSize = true;
            this.label_checking_ytdlp.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_checking_ytdlp.Location = new System.Drawing.Point(341, 0);
            this.label_checking_ytdlp.Name = "label_checking_ytdlp";
            this.label_checking_ytdlp.Size = new System.Drawing.Size(59, 41);
            this.label_checking_ytdlp.TabIndex = 5;
            this.label_checking_ytdlp.Text = "❌";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Downloading FFmpeg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Downloading yt-dlp";
            // 
            // label_checking_ffmpeg
            // 
            this.label_checking_ffmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_checking_ffmpeg.AutoSize = true;
            this.label_checking_ffmpeg.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_checking_ffmpeg.Location = new System.Drawing.Point(341, 59);
            this.label_checking_ffmpeg.Name = "label_checking_ffmpeg";
            this.label_checking_ffmpeg.Size = new System.Drawing.Size(59, 41);
            this.label_checking_ffmpeg.TabIndex = 6;
            this.label_checking_ffmpeg.Text = "❌";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.64433F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.35567F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_youtube, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_segment, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 76);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Segment";
            // 
            // textBox_youtube
            // 
            this.textBox_youtube.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_youtube.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_youtube.Location = new System.Drawing.Point(202, 3);
            this.textBox_youtube.Name = "textBox_youtube";
            this.textBox_youtube.Size = new System.Drawing.Size(571, 32);
            this.textBox_youtube.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Youtube Link";
            // 
            // checkBox_segment
            // 
            this.checkBox_segment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_segment.AutoSize = true;
            this.checkBox_segment.Checked = true;
            this.checkBox_segment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_segment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 21.91304F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_segment.Location = new System.Drawing.Point(202, 50);
            this.checkBox_segment.Name = "checkBox_segment";
            this.checkBox_segment.Size = new System.Drawing.Size(15, 14);
            this.checkBox_segment.TabIndex = 2;
            this.checkBox_segment.UseVisualStyleBackColor = true;
            this.checkBox_segment.CheckedChanged += new System.EventHandler(this.checkBox_segment_CheckedChanged);
            // 
            // tableLayoutPanel_segment
            // 
            this.tableLayoutPanel_segment.ColumnCount = 2;
            this.tableLayoutPanel_segment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.64433F));
            this.tableLayoutPanel_segment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.35567F));
            this.tableLayoutPanel_segment.Controls.Add(this.textBox_end, 1, 1);
            this.tableLayoutPanel_segment.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel_segment.Controls.Add(this.textBox_start, 1, 0);
            this.tableLayoutPanel_segment.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel_segment.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel_segment.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel_segment.Name = "tableLayoutPanel_segment";
            this.tableLayoutPanel_segment.RowCount = 2;
            this.tableLayoutPanel_segment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_segment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_segment.Size = new System.Drawing.Size(776, 76);
            this.tableLayoutPanel_segment.TabIndex = 2;
            // 
            // textBox_end
            // 
            this.textBox_end.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_end.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_end.Location = new System.Drawing.Point(202, 41);
            this.textBox_end.Name = "textBox_end";
            this.textBox_end.Size = new System.Drawing.Size(92, 32);
            this.textBox_end.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "End";
            // 
            // textBox_start
            // 
            this.textBox_start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_start.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_start.Location = new System.Drawing.Point(202, 3);
            this.textBox_start.Name = "textBox_start";
            this.textBox_start.Size = new System.Drawing.Size(92, 32);
            this.textBox_start.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Start";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.64433F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.35567F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 164);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(776, 76);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(202, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(571, 32);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "%(upload_date)s %(title)s (%(id)s).%(ext)s";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 28);
            this.label7.TabIndex = 2;
            this.label7.Text = "Output Template";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(202, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(571, 32);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "./";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Output Directory";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(606, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 66);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 247);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(588, 66);
            this.progressBar1.TabIndex = 5;
            // 
            // panel_download
            // 
            this.panel_download.BackColor = System.Drawing.SystemColors.Control;
            this.panel_download.Controls.Add(this.panel1);
            this.panel_download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_download.Location = new System.Drawing.Point(0, 0);
            this.panel_download.Name = "panel_download";
            this.panel_download.Size = new System.Drawing.Size(800, 325);
            this.panel_download.TabIndex = 6;
            this.panel_download.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 325);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel_segment);
            this.Controls.Add(this.panel_download);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Youtube Segment Downloader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_segment.ResumeLayout(false);
            this.tableLayoutPanel_segment.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_download.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label_checking_ytdlp;
        private Label label2;
        private Label label1;
        private Label label_checking_ffmpeg;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private TextBox textBox_youtube;
        private Label label4;
        private CheckBox checkBox_segment;
        private TableLayoutPanel tableLayoutPanel_segment;
        private TextBox textBox_start;
        private Label label6;
        private Label label5;
        private TextBox textBox_end;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox2;
        private Label label8;
        private Button button1;
        private ProgressBar progressBar1;
        private Panel panel_download;
    }
}