namespace Framework48FormsDemo
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
            this.btnDisplayFromFile = new System.Windows.Forms.Button();
            this.btnCreateFromLib = new System.Windows.Forms.Button();
            this.picLibDisp = new System.Windows.Forms.PictureBox();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.cbEmoji = new System.Windows.Forms.ComboBox();
            this.lblEmoji = new System.Windows.Forms.Label();
            this.ImageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFromLib = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLibDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisplayFromFile
            // 
            this.btnDisplayFromFile.Enabled = false;
            this.btnDisplayFromFile.Location = new System.Drawing.Point(198, 89);
            this.btnDisplayFromFile.Name = "btnDisplayFromFile";
            this.btnDisplayFromFile.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayFromFile.TabIndex = 2;
            this.btnDisplayFromFile.Text = "From File";
            this.btnDisplayFromFile.UseVisualStyleBackColor = true;
            this.btnDisplayFromFile.Click += new System.EventHandler(this.btnDisplayFromFile_Click);
            // 
            // btnCreateFromLib
            // 
            this.btnCreateFromLib.Enabled = false;
            this.btnCreateFromLib.Location = new System.Drawing.Point(117, 89);
            this.btnCreateFromLib.Name = "btnCreateFromLib";
            this.btnCreateFromLib.Size = new System.Drawing.Size(75, 23);
            this.btnCreateFromLib.TabIndex = 3;
            this.btnCreateFromLib.Text = "From Library";
            this.btnCreateFromLib.UseVisualStyleBackColor = true;
            this.btnCreateFromLib.Click += new System.EventHandler(this.btnCreateFromLib_Click);
            // 
            // picLibDisp
            // 
            this.picLibDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.picLibDisp.Location = new System.Drawing.Point(114, 118);
            this.picLibDisp.Name = "picLibDisp";
            this.picLibDisp.Size = new System.Drawing.Size(80, 80);
            this.picLibDisp.TabIndex = 4;
            this.picLibDisp.TabStop = false;
            // 
            // cbGroup
            // 
            this.cbGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(0, 0);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(719, 21);
            this.cbGroup.TabIndex = 7;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            // 
            // cbEmoji
            // 
            this.cbEmoji.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbEmoji.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmoji.FormattingEnabled = true;
            this.cbEmoji.Location = new System.Drawing.Point(0, 21);
            this.cbEmoji.Name = "cbEmoji";
            this.cbEmoji.Size = new System.Drawing.Size(719, 21);
            this.cbEmoji.TabIndex = 8;
            this.cbEmoji.SelectedIndexChanged += new System.EventHandler(this.cbEmoji_SelectedIndexChanged);
            // 
            // lblEmoji
            // 
            this.lblEmoji.AutoSize = true;
            this.lblEmoji.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmoji.Location = new System.Drawing.Point(45, 79);
            this.lblEmoji.Name = "lblEmoji";
            this.lblEmoji.Size = new System.Drawing.Size(67, 28);
            this.lblEmoji.TabIndex = 9;
            this.lblEmoji.Text = "label1";
            // 
            // ImageSizeComboBox
            // 
            this.ImageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImageSizeComboBox.FormattingEnabled = true;
            this.ImageSizeComboBox.Items.AddRange(new object[] {
            "16x16",
            "32x32",
            "64x64",
            "128x128",
            "256x256",
            "512x512"});
            this.ImageSizeComboBox.Location = new System.Drawing.Point(117, 49);
            this.ImageSizeComboBox.Name = "ImageSizeComboBox";
            this.ImageSizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.ImageSizeComboBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Image Size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromLib
            // 
            this.lblFromLib.AutoSize = true;
            this.lblFromLib.Location = new System.Drawing.Point(279, 94);
            this.lblFromLib.Name = "lblFromLib";
            this.lblFromLib.Size = new System.Drawing.Size(35, 13);
            this.lblFromLib.TabIndex = 12;
            this.lblFromLib.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(719, 631);
            this.Controls.Add(this.lblFromLib);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImageSizeComboBox);
            this.Controls.Add(this.lblEmoji);
            this.Controls.Add(this.cbEmoji);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.picLibDisp);
            this.Controls.Add(this.btnCreateFromLib);
            this.Controls.Add(this.btnDisplayFromFile);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLibDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDisplayFromFile;
        private System.Windows.Forms.Button btnCreateFromLib;
        private System.Windows.Forms.PictureBox picLibDisp;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ComboBox cbEmoji;
        private System.Windows.Forms.Label lblEmoji;
        private System.Windows.Forms.ComboBox ImageSizeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFromLib;
    }
}

