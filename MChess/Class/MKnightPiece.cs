using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace MChess
{
    class MKnightPiece : MChessPiece
    {
        public MKnightPiece(short pieceSide)
        {
            name = "Knight";
            hasMoved = false;
            isCaptuable = false;
            side = pieceSide;
        }

        public override ArrayList GenerateLegalMove(MyPoint location, MBoard board)
        {
            ArrayList myArray = new ArrayList();
            int row;
            int col;

            // Trên 1 trái 2
            row = location.row - 1;
            col = location.col - 2;

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

            // Trên 2 trái 1
            row = location.row - 2;
            col = location.col - 1;

            if (row >= 0 && col >= 0)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            // Trên 1 phải 2
            row = location.row - 1;
            col = location.col + 2;

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

            // Trên 2 phải 1
            row = location.row - 2;
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

            // Dưới 1 trái 2
            row = location.row + 1;
            col = location.col - 2;

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

            // Dưới 2 trái 1
            row = location.row + 2;
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

            // Dưới 1 phải 2
            row = location.row + 1;
            col = location.col + 2;

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

            // Dưới 2 phải 1
            row = location.row + 2;
            col = location.col + 1;

            if (row <= 7 && col <= 7)
            {
                if (board.square[row, col].side != side)
                {
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = row;
                    myPoint.col = col;
                    myArray.Add(myPoint);
                }
            }

            return myArray;
        }

        public override int GetWeight(MyPoint location)
        {
            return 35;
        }
    }
}
