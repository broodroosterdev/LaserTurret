namespace LaserTurret
{
    partial class LaserBoi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaserBoi));
            this.resetposition = new System.Windows.Forms.Button();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.makesquare = new System.Windows.Forms.Button();
            this.COMPortBox = new System.Windows.Forms.ComboBox();
            this.compoort_label = new System.Windows.Forms.Label();
            this.LaserProgress = new System.Windows.Forms.ProgressBar();
            this.progress_label = new System.Windows.Forms.Label();
            this.drawpanel = new System.Windows.Forms.Panel();
            this.cleardraw = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resetposition
            // 
            this.resetposition.Location = new System.Drawing.Point(430, 52);
            this.resetposition.Name = "resetposition";
            this.resetposition.Size = new System.Drawing.Size(106, 64);
            this.resetposition.TabIndex = 0;
            this.resetposition.Text = "Reset Position";
            this.resetposition.UseVisualStyleBackColor = true;
            this.resetposition.Click += new System.EventHandler(this.ResetPosition_click);
            // 
            // makesquare
            // 
            this.makesquare.Location = new System.Drawing.Point(430, 122);
            this.makesquare.Name = "makesquare";
            this.makesquare.Size = new System.Drawing.Size(106, 64);
            this.makesquare.TabIndex = 1;
            this.makesquare.Text = "Make Square";
            this.makesquare.UseVisualStyleBackColor = true;
            this.makesquare.Click += new System.EventHandler(this.MakeSquare_click);
            // 
            // COMPortBox
            // 
            this.COMPortBox.FormattingEnabled = true;
            this.COMPortBox.Location = new System.Drawing.Point(430, 25);
            this.COMPortBox.Name = "COMPortBox";
            this.COMPortBox.Size = new System.Drawing.Size(84, 21);
            this.COMPortBox.TabIndex = 2;
            this.COMPortBox.SelectedIndexChanged += new System.EventHandler(this.COMPortBox_SelectedIndexChanged);
            // 
            // compoort_label
            // 
            this.compoort_label.AutoSize = true;
            this.compoort_label.Location = new System.Drawing.Point(427, 9);
            this.compoort_label.Name = "compoort_label";
            this.compoort_label.Size = new System.Drawing.Size(62, 13);
            this.compoort_label.TabIndex = 3;
            this.compoort_label.Text = "COM Poort:";
            // 
            // LaserProgress
            // 
            this.LaserProgress.Location = new System.Drawing.Point(12, 357);
            this.LaserProgress.MarqueeAnimationSpeed = 25;
            this.LaserProgress.Name = "LaserProgress";
            this.LaserProgress.Size = new System.Drawing.Size(409, 23);
            this.LaserProgress.TabIndex = 4;
            // 
            // progress_label
            // 
            this.progress_label.AllowDrop = true;
            this.progress_label.AutoSize = true;
            this.progress_label.Location = new System.Drawing.Point(12, 341);
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(51, 13);
            this.progress_label.TabIndex = 5;
            this.progress_label.Text = "Progress:";
            this.progress_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // drawpanel
            // 
            this.drawpanel.BackColor = System.Drawing.Color.White;
            this.drawpanel.Location = new System.Drawing.Point(13, 13);
            this.drawpanel.Name = "drawpanel";
            this.drawpanel.Size = new System.Drawing.Size(411, 325);
            this.drawpanel.TabIndex = 6;
            this.drawpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawpanel_MouseDown);
            this.drawpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawpanel_MouseMove);
            // 
            // cleardraw
            // 
            this.cleardraw.Location = new System.Drawing.Point(430, 262);
            this.cleardraw.Name = "cleardraw";
            this.cleardraw.Size = new System.Drawing.Size(106, 64);
            this.cleardraw.TabIndex = 7;
            this.cleardraw.Text = "Clear Draw";
            this.cleardraw.UseVisualStyleBackColor = true;
            this.cleardraw.Click += new System.EventHandler(this.cleardraw_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 64);
            this.button1.TabIndex = 8;
            this.button1.Text = "Make Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.makedraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Last coordinates:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // LaserBoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(543, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cleardraw);
            this.Controls.Add(this.drawpanel);
            this.Controls.Add(this.progress_label);
            this.Controls.Add(this.LaserProgress);
            this.Controls.Add(this.compoort_label);
            this.Controls.Add(this.COMPortBox);
            this.Controls.Add(this.makesquare);
            this.Controls.Add(this.resetposition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaserBoi";
            this.Text = "LaserBoi";
            this.Load += new System.EventHandler(this.LaserBoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetposition;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Button makesquare;
        private System.Windows.Forms.ComboBox COMPortBox;
        private System.Windows.Forms.Label compoort_label;
        private System.Windows.Forms.ProgressBar LaserProgress;
        private System.Windows.Forms.Label progress_label;
        private System.Windows.Forms.Panel drawpanel;
        private System.Windows.Forms.Button cleardraw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

