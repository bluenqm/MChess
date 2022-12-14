using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace MChess
{
    class MKingPiece : MChessPiece
    {
        public MKingPiece(short pieceSide)
        {
            name = "King";
            hasMoved = false;
            isCaptuable = false;
            side = pieceSide;
        }

        public override ArrayList GenerateLegalMove(MyPoint location, MBoard board)
        {
            ArrayList myArray = new ArrayList();
            int row;
            int col;

            // Chéo trên trái
            row = location.row - 1;
            col = location.col - 1;

            if (col >= 0 && row >= 0)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Chéo trên phải
            row = location.row + 1;
            col = location.col - 1;

            if (row <= 7 && col >= 0)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Chéo dưới trái
            row = location.row - 1;
            col = location.col + 1;

            if (row >= 0 && col <= 7)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Chéo dưới phải
            row = location.row + 1;
            col = location.col + 1;

            if (col <= 7 && row <= 7)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Đi lên
            row = location.row - 1;
            col = location.col;

            if (row >= 0)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Đi xuống
            row = location.row + 1;
            col = location.col;

            if (row <= 7)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Đi qua trái
            row = location.row;
            col = location.col - 1;

            if (col >= 0)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Đi qua phải
            row = location.row;
            col = location.col + 1;

            if (col <= 7)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Nhập thành
            if (hasMoved == false)
            {
                // Nhập thành trái
                if (board.square[location.row, 1].side == 0 &&
                    board.square[location.row, 2].side == 0 &&
                    board.square[location.row, 3].side == 0 &&
                    board.square[location.row, 0].side == side &&
                    board.square[location.row, 0].name == "Rook" &&
                    board.square[location.row, 0].hasMoved == false)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = 2;
                    myArray.Add(myPoint);
                }

                // Nhập thành phải
                if (board.square[location.row, 5].side == 0 &&
                    board.square[location.row, 6].side == 0 &&
                    board.square[location.row, 7].side == side &&
                    board.square[location.row, 7].name == "Rook" &&
                    board.square[location.row, 7].hasMoved == false)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = 6;
                    myArray.Add(myPoint);
                }
            }

            return myArray;
        }

        public override int GetWeight(MyPoint location)
        {
            return 100;
        }
    }
}
