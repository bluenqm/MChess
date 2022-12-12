using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace MChess
{
    class MQueenPiece : MChessPiece
    {
        public MQueenPiece(short pieceSide)
        {
            name = "Queen";
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

            while (col >= 0 && row >= 0)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                col--;
                row--;
            }

            // Chéo trên phải
            row = location.row + 1;
            col = location.col - 1;

            while (row <= 7 && col >= 0)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                row++;
                col--;
            }


            // Chéo dưới trái
            row = location.row - 1;
            col = location.col + 1;

            while (row >= 0 && col <= 7)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                row--;
                col++;
            }

            // Chéo dưới phải
            row = location.row + 1;
            col = location.col + 1;

            while (col <= 7 && row <= 7)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                col++;
                row++;
            }

            // Đi lên
            row = location.row - 1;
            col = location.col;

            while (row >= 0)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                row--;
            }

            // Đi xuống
            row = location.row + 1;
            col = location.col;

            while (row <= 7)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                row++;
            }

            // Đi qua trái
            row = location.row;
            col = location.col - 1;

            while (col >= 0)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                col--;
            }

            // Đi qua phải
            row = location.row;
            col = location.col + 1;

            while (col <= 7)
            {
                if (board.square[row, col].side == side)
                    break;

                MyPoint myPoint = new MyPoint();
                myPoint.row = row;
                myPoint.col = col;
                myArray.Add(myPoint);

                if (board.square[row, col].side != 0)
                    break;

                col++;
            }

            return myArray;
        }

        public override int GetWeight(MyPoint location)
        {
            return 50;
        }
    }
}
