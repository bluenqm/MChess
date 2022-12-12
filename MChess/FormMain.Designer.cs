using System.Drawing;
namespace MChess
{
    partial class FormMain
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
            this.buttonSound = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // buttonSound
            // 
            this.buttonSound.Location = new System.Drawing.Point(165, 271);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(72, 20);
            this.buttonSound.TabIndex = 0;
            this.buttonSound.Text = "ON";
            this.buttonSound.Visible = false;
            this.buttonSound.Click += new System.EventHandler(this.buttonSound_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(240, 265);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.buttonSound);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "FormMain";
            this.Text = "M-Chess";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSound;
        private System.Windows.Forms.PictureBox pictureBoxMain;







    }
}

