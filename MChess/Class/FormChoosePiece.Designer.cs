namespace MChess.Class
{
    partial class FormChoosePiece
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.labelAsk = new System.Windows.Forms.Label();
            this.pictureBoxPiece = new System.Windows.Forms.PictureBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAsk
            // 
            this.labelAsk.Location = new System.Drawing.Point(3, 40);
            this.labelAsk.Name = "labelAsk";
            this.labelAsk.Size = new System.Drawing.Size(234, 20);
            this.labelAsk.Text = "Bạn muốn phong quân Chốt thành quân:";
            // 
            // pictureBoxPiece
            // 
            this.pictureBoxPiece.Location = new System.Drawing.Point(67, 76);
            this.pictureBoxPiece.Name = "pictureBoxPiece";
            this.pictureBoxPiece.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxPiece.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(173, 111);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(40, 20);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = ">";
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(21, 111);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(40, 20);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.Text = "<";
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(67, 195);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 20);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormChoosePiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.pictureBoxPiece);
            this.Controls.Add(this.labelAsk);
            this.Menu = this.mainMenu1;
            this.Name = "FormChoosePiece";
            this.Text = "FormChoosePiece";
            this.Load += new System.EventHandler(this.FormChoosePiece_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAsk;
        private System.Windows.Forms.PictureBox pictureBoxPiece;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonOK;

    }
}