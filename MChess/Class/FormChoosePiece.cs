using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MChess.Class
{
    public partial class FormChoosePiece : Form
    {
        public FormChoosePiece()
        {
            InitializeComponent();
        }

        private string imagePath;
        private string path = MConstant.GetPath();
        public int pos;

        private void FormChoosePiece_Load(object sender, EventArgs e)
        {
            imagePath = path + "/Bitmap/queen21.bmp";
            UpdateDraw();
        }

        private void UpdateDraw()
        {
            switch (pos)
            {
                case 1:
                    imagePath = path + "/Bitmap/rook21.bmp";
                    break;
                case 2:
                    imagePath = path + "/Bitmap/knight21.bmp";
                    break;
                case 3:
                    imagePath = path + "/Bitmap/bishop21.bmp";
                    break;
                case 4:
                    imagePath = path + "/Bitmap/queen21.bmp";
                    break;
            }
            Bitmap image = new Bitmap(imagePath);
            pictureBoxPiece.Image = image;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos == 5)
                pos = 1;
            UpdateDraw();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos == 0)
                pos = 4;
            UpdateDraw();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}