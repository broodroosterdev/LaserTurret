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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resetposition
            // 
            this.resetposition.Location = new System.Drawing.Point(124, 12);
            this.resetposition.Name = "resetposition";
            this.resetposition.Size = new System.Drawing.Size(106, 64);
            this.resetposition.TabIndex = 0;
            this.resetposition.Text = "Reset Position";
            this.resetposition.UseVisualStyleBackColor = true;
            this.resetposition.Click += new System.EventHandler(this.ResetPosition_click);
            // 
            // makesquare
            // 
            this.makesquare.Location = new System.Drawing.Point(12, 12);
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
            this.COMPortBox.Location = new System.Drawing.Point(236, 35);
            this.COMPortBox.Name = "COMPortBox";
            this.COMPortBox.Size = new System.Drawing.Size(84, 21);
            this.COMPortBox.TabIndex = 2;
            this.COMPortBox.SelectedIndexChanged += new System.EventHandler(this.COMPortBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "COM Poort:";
            // 
            // LaserBoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 83);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}

