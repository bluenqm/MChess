using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using PlaySound;
using MChess.Class;

namespace MChess
{
    public partial class FormMain : Form
    {
        public MBoard mBoard;
        public PictureBox[,] chessBoard;
        private bool moving;
        private MyPoint movingPiece;
        private ArrayList movingPosition;

        private Thread SoundThread;

        public FormMain()
        {
            InitializeComponent();

            moving = false;
            movingPiece = new MyPoint();
            movingPosition = new ArrayList();

            chessBoard = new PictureBox[8, 8];
            for(int i=0; i<8; i++)
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = new PictureBox();
                    chessBoard[i, j].Name = i.ToString() + j.ToString();
                    chessBoard[i, j].Size = new Size(30, 30);
                    chessBoard[i, j].Location = new Point(j * 30, i * 30);
                    chessBoard[i, j].Click += new EventHandler(this.chessBoard_Click);
                    this.Controls.Add(chessBoard[i, j]);
                }
        }

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            string path = MConstant.GetPath();
            Bitmap a = new Bitmap(path + "/Bitmap/start.bmp");
            pictureBoxMain.Image = a;
        }

        /// <summary>
        /// Người đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chessBoard_Click(object sender, EventArgs e)
        {
            PictureBox myPictureBox = (PictureBox)sender;
            int col = myPictureBox.Location.X / 30;
            int row = myPictureBox.Location.Y / 30;

            if (moving == false)
            {
                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;

                if (mBoard.square[row, col].side == 1)
                    return;

                movingPiece = myPoint;
                ArrayList myArrayList = mBoard.square[row, col].GenerateLegalMove(myPoint, mBoard);

                if (myArrayList.Count == 0)
                    return;

                movingPosition = myArrayList;
                foreach (MyPoint p in myArrayList)
                    chessBoard[p.row, p.col].Image = new Bitmap(MConstant.GetPath() + "/Bitmap/blue.bmp");

                moving = true;
            }
            else
            {
                moving = false;

                bool move = false;

                for (int i = 0; i < movingPosition.Count; i++)
                {
                    MyPoint p = (MyPoint)movingPosition[i];
                    if (p.row == row && p.col == col)
                    {
                        move = true;
                        break;
                    }
                }

                if (move == false)
                {
                    Draw();
                    return;
                }

                mBoard.square[row, col] = mBoard.square[movingPiece.row, movingPiece.col];
                mBoard.square[row, col].hasMoved = true;
                mBoard.square[movingPiece.row, movingPiece.col] = new MChessPiece();

                // Nhập thành
                MyPoint point = new MyPoint(row, col);

                if (row == 7 && mBoard.square[7, col].name == "King")
                {
                    // trái
                    if (movingPiece.col == col + 2)
                    {
                        mBoard.square[7, 3] = mBoard.square[7, 0];
                        mBoard.square[7, 0] = new MChessPiece();
                    }

                    // phải
                    if (movingPiece.col == col - 2)
                    {
                        mBoard.square[7, 5] = mBoard.square[7, 7];
                        mBoard.square[7, 7] = new MChessPiece();
                    }
                }

                if (CheckWin() == 2)
                {
                    WPlaySound.PlaySoundEvent(MConstant.GetPath() + "Wav/tada.wav");
                    pictureBoxMain.Visible = true;
                    Bitmap bitmap = new Bitmap(MConstant.GetPath() + "Bitmap/win.bmp");
                    pictureBoxMain.Image = bitmap;
                    return;
                }

                else
                {
                    // Người phong hậu
                    if (mBoard.square[row, col].name == "Pawn" && row == 0)
                    {
                        FormChoosePiece form = new FormChoosePiece();
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            switch (form.pos)
                            {
                                case 1:
                                    mBoard.square[row, col] = new MRookPiece(2);
                                    break;
                                case 2:
                                    mBoard.square[row, col] = new MKnightPiece(2);
                                    break;
                                case 3:
                                    mBoard.square[row, col] = new MBishopPiece(2);
                                    break;
                                default:
                                    mBoard.square[row, col] = new MQueenPiece(2);
                                    break;
                            }
                        }
                    }

                    WPlaySound.PlaySoundEvent(MConstant.GetPath() + "Wav/start.wav");
                    Draw();
                }

                ComputerMove();
            }
        }

        private void ComputerMove()
        {
            // Máy đi
            mBoard = mBoard.ComputerMove();
            WPlaySound.PlaySoundEvent(MConstant.GetPath() + "Wav/start.wav");
            Draw();

            if (CheckWin() == 1)
            {
                WPlaySound.PlaySoundEvent(MConstant.GetPath() + "Wav/lose.wav");
                pictureBoxMain.Visible = true;
                Bitmap bitmap = new Bitmap(MConstant.GetPath() + "Bitmap/lost.bmp");
                pictureBoxMain.Image = bitmap;
            }
        }

        /// <summary>
        /// Kiểm tra bên nào thắng
        /// </summary>
        /// <returns></returns>
        public int CheckWin()
        {
            int result = 0;

            foreach (MChessPiece p in mBoard.square)
            {
                if (p.name == "King" && p.side == 1)
                    result += 1;
                if (p.name == "King" && p.side == 2)
                    result += 2;
            }

            return result;
        }

        /// <summary>
        /// Vẽ bàn cờ
        /// </summary>
        private void Draw()
        {
            string path = MConstant.GetPath();
            string imagePath = "";
            Bitmap image;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)   // ô trắng
                    {
                        switch (mBoard.square[i, j].side)
                        {
                            case 0: // không có quân nào
                                imagePath = path + "/Bitmap/white.bmp";
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                            case 1: // quân đỏ = máy
                                switch (mBoard.square[i, j].name)
                                {
                                    case "Pawn":
                                        imagePath = path + "/Bitmap/pawn11.bmp";
                                        break;
                                    case "Rook":
                                        imagePath = path + "/Bitmap/rook11.bmp";
                                        break;
                                    case "Knight":
                                        imagePath = path + "/Bitmap/knight11.bmp";
                                        break;
                                    case "Bishop":
                                        imagePath = path + "/Bitmap/bishop11.bmp";
                                        break;
                                    case "King":
                                        imagePath = path + "/Bitmap/king11.bmp";
                                        break;
                                    case "Queen":
                                        imagePath = path + "/Bitmap/queen11.bmp";
                                        break;
                                }
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                            case 2: // quân xanh = người
                                switch (mBoard.square[i, j].name)
                                {
                                    case "Pawn":
                                        imagePath = path + "/Bitmap/pawn21.bmp";
                                        break;
                                    case "Rook":
                                        imagePath = path + "/Bitmap/rook21.bmp";
                                        break;
                                    case "Knight":
                                        imagePath = path + "/Bitmap/knight21.bmp";
                                        break;
                                    case "Bishop":
                                        imagePath = path + "/Bitmap/bishop21.bmp";
                                        break;
                                    case "King":
                                        imagePath = path + "/Bitmap/king21.bmp";
                                        break;
                                    case "Queen":
                                        imagePath = path + "/Bitmap/queen21.bmp";
                                        break;
                                }
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                        }
                    }
                    else // ô đen
                    {
                        switch (mBoard.square[i, j].side)
                        {
                            case 0: // không có quân nào
                                imagePath = path + "/Bitmap/black.bmp";
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                            case 1: // quân xanh
                                switch (mBoard.square[i, j].name)
                                {
                                    case "Pawn":
                                        imagePath = path + "/Bitmap/pawn12.bmp";
                                        break;
                                    case "Rook":
                                        imagePath = path + "/Bitmap/rook12.bmp";
                                        break;
                                    case "Knight":
                                        imagePath = path + "/Bitmap/knight12.bmp";
                                        break;
                                    case "Bishop":
                                        imagePath = path + "/Bitmap/bishop12.bmp";
                                        break;
                                    case "King":
                                        imagePath = path + "/Bitmap/king12.bmp";
                                        break;
                                    case "Queen":
                                        imagePath = path + "/Bitmap/queen12.bmp";
                                        break;
                                }
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                            case 2: // quân đỏ
                                switch (mBoard.square[i, j].name)
                                {
                                    case "Pawn":
                                        imagePath = path + "/Bitmap/pawn22.bmp";
                                        break;
                                    case "Rook":
                                        imagePath = path + "/Bitmap/rook22.bmp";
                                        break;
                                    case "Knight":
                                        imagePath = path + "/Bitmap/knight22.bmp";
                                        break;
                                    case "Bishop":
                                        imagePath = path + "/Bitmap/bishop22.bmp";
                                        break;
                                    case "King":
                                        imagePath = path + "/Bitmap/king22.bmp";
                                        break;
                                    case "Queen":
                                        imagePath = path + "/Bitmap/queen22.bmp";
                                        break;
                                }
                                image = new Bitmap(imagePath);
                                chessBoard[i, j].Image = image;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Bật/tắt nhạc nền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSound_Click(object sender, EventArgs e)
        {
            if (buttonSound.Text == "ON")
            {
                buttonSound.Text = "OFF";
            }
            else
            {
                buttonSound.Text = "ON";
            }
        }

        /// <summary>
        /// Hình khởi động
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMain_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Visible = false;
            mBoard = new MBoard();
            Draw();
        }
        
        
        private void PlaySoundBackGround()
        {
            SoundThread = new Thread(new ThreadStart(PlaySoundFunc));
            SoundThread.Priority = ThreadPriority.Highest;

            SoundThread.Start();
        }

        private void PlaySoundFunc()
        {
            WPlaySound.PlaySoundEvent("");
        }
    }
}