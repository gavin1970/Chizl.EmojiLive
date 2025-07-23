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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFileDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLibDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // picFileDisp
            // 
            this.picFileDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.picFileDisp.Location = new System.Drawing.Point(304, 41);
            this.picFileDisp.Name = "picFileDisp";
            this.picFileDisp.Size = new System.Drawing.Size(250, 194);
            this.picFileDisp.TabIndex = 1;
            this.picFileDisp.TabStop = false;
            // 
            // btnDisplayFromFile
            // 
            this.btnDisplayFromFile.Location = new System.Drawing.Point(304, 12);
            this.btnDisplayFromFile.Name = "btnDisplayFromFile";
            this.btnDisplayFromFile.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayFromFile.TabIndex = 2;
            this.btnDisplayFromFile.Text = "From File";
            this.btnDisplayFromFile.UseVisualStyleBackColor = true;
            this.btnDisplayFromFile.Click += new System.EventHandler(this.btnDisplayFromFile_Click);
            // 
            // btnCreateFromLib
            // 
            this.btnCreateFromLib.Location = new System.Drawing.Point(12, 12);
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
            this.picLibDisp.Location = new System.Drawing.Point(12, 41);
            this.picLibDisp.Name = "picLibDisp";
            this.picLibDisp.Size = new System.Drawing.Size(250, 194);
            this.picLibDisp.TabIndex = 4;
            this.picLibDisp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLibDisp);
            this.Controls.Add(this.btnCreateFromLib);
            this.Controls.Add(this.btnDisplayFromFile);
            this.Controls.Add(this.picFileDisp);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label label1;
    }
}

