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
            this.picFileDisp = new System.Windows.Forms.PictureBox();
            this.btnDisplayFromFile = new System.Windows.Forms.Button();
            this.btnCreateFromLib = new System.Windows.Forms.Button();
            this.picLibDisp = new System.Windows.Forms.PictureBox();
            this.lblFromFile = new System.Windows.Forms.Label();
            this.lblFromLib = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.cbEmoji = new System.Windows.Forms.ComboBox();
            this.lblEmoji = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFileDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLibDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // picFileDisp
            // 
            this.picFileDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.picFileDisp.Location = new System.Drawing.Point(182, 214);
            this.picFileDisp.Name = "picFileDisp";
            this.picFileDisp.Size = new System.Drawing.Size(80, 80);
            this.picFileDisp.TabIndex = 1;
            this.picFileDisp.TabStop = false;
            // 
            // btnDisplayFromFile
            // 
            this.btnDisplayFromFile.Enabled = false;
            this.btnDisplayFromFile.Location = new System.Drawing.Point(185, 185);
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
            this.btnCreateFromLib.Location = new System.Drawing.Point(185, 50);
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
            this.picLibDisp.Location = new System.Drawing.Point(182, 79);
            this.picLibDisp.Name = "picLibDisp";
            this.picLibDisp.Size = new System.Drawing.Size(80, 80);
            this.picLibDisp.TabIndex = 4;
            this.picLibDisp.TabStop = false;
            // 
            // lblFromFile
            // 
            this.lblFromFile.Location = new System.Drawing.Point(205, 297);
            this.lblFromFile.Name = "lblFromFile";
            this.lblFromFile.Size = new System.Drawing.Size(35, 13);
            this.lblFromFile.TabIndex = 5;
            this.lblFromFile.Text = "label1";
            this.lblFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromLib
            // 
            this.lblFromLib.Location = new System.Drawing.Point(205, 162);
            this.lblFromLib.Name = "lblFromLib";
            this.lblFromLib.Size = new System.Drawing.Size(35, 13);
            this.lblFromLib.TabIndex = 6;
            this.lblFromLib.Text = "label2";
            this.lblFromLib.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbGroup
            // 
            this.cbGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(0, 0);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(446, 21);
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
            this.cbEmoji.Size = new System.Drawing.Size(446, 21);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(446, 333);
            this.Controls.Add(this.lblEmoji);
            this.Controls.Add(this.cbEmoji);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.lblFromLib);
            this.Controls.Add(this.lblFromFile);
            this.Controls.Add(this.picLibDisp);
            this.Controls.Add(this.btnCreateFromLib);
            this.Controls.Add(this.btnDisplayFromFile);
            this.Controls.Add(this.picFileDisp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFileDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLibDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picFileDisp;
        private System.Windows.Forms.Button btnDisplayFromFile;
        private System.Windows.Forms.Button btnCreateFromLib;
        private System.Windows.Forms.PictureBox picLibDisp;
        private System.Windows.Forms.Label lblFromFile;
        private System.Windows.Forms.Label lblFromLib;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ComboBox cbEmoji;
        private System.Windows.Forms.Label lblEmoji;
    }
}

