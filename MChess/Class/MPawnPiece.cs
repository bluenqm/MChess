using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace MChess
{
    class MPawnPiece : MChessPiece
    {
        public MPawnPiece(short pieceSide)
        {
            name = "Pawn";
            hasMoved = false;
            isCaptuable = false;
            side = pieceSide;
        }

        public override ArrayList GenerateLegalMove(MyPoint location, MBoard board)
        {
            ArrayList myArray = new ArrayList();
            int row = location.row;
            int col = location.col;

            switch (side)
            {
                case 1: // máy = đỏ
                    if (location.row < 7)
                    {
                        // Đi thẳng
                        if (board.square[location.row + 1, location.col].side == 0)
                        {
                            MyPoint myPoint = new MyPoint();
                            myPoint.row = row + 1;
                            myPoint.col = col;
                            myArray.Add(myPoint);
                        }
                        // Ăn chéo trái
                        if(location.col > 0)
                            if (board.square[location.row + 1, location.col - 1].side == 2)
                            {
                                MyPoint myPoint = new MyPoint();
                                myPoint.row = row + 1;
                                myPoint.col = col - 1;
                                myArray.Add(myPoint);
                            }
                        // Ăn chéo phải
                        if (location.col < 7)
                            if (board.square[location.row + 1, location.col + 1].side == 2)
                            {
                                MyPoint myPoint = new MyPoint();
                                myPoint.row = row + 1;
                                myPoint.col = col + 1;
                                myArray.Add(myPoint);
                            }
                    }

                    // Đi 2 bước
                    if (location.row == 1)
                        if (board.square[location.row + 2, location.col].side == 0 && board.square[location.row + 1, location.col].side == 0)
                        {
                            MyPoint myPoint = new MyPoint();
                            myPoint.row = row + 2;
                            myPoint.col = col;
                            myArray.Add(myPoint);
                        }     
                    break;
                case 2: // người = xanh
                    if (location.row > 0)
                    {
                        // Đi thẳng
                        if (board.square[location.row - 1, location.col].side == 0)
                        {
                            MyPoint myPoint = new MyPoint();
                            myPoint.row = row - 1;
                            myPoint.col = col;
                            myArray.Add(myPoint);
                        }
                        // Ăn chéo trái
                        if (location.col > 0)
                            if (board.square[location.row - 1, location.col - 1].side == 1)
                            {
                                MyPoint myPoint = new MyPoint();
                                myPoint.row = row - 1;
                                myPoint.col = col - 1;
                                myArray.Add(myPoint);
                            }
                        // Ăn chéo phải
                        if (location.col < 7)
                            if (board.square[location.row - 1, location.col + 1].side == 1)
                            {
                                MyPoint myPoint = new MyPoint();
                                myPoint.row = row - 1;
                                myPoint.col = col + 1;
                                myArray.Add(myPoint);
                            }
                    }

                    // Đi 2 bước
                    if (location.row == 6)
                        if (board.square[location.row - 2, location.col].side == 0)
                        {
                            MyPoint myPoint = new MyPoint();
                            myPoint.row = row - 2;
                            myPoint.col = col;
                            myArray.Add(myPoint);
                        }
                    break;
            }

            return myArray;
        }

        public override int GetWeight(MyPoint location)
        {
            int result = 0;

            switch (side)
            {
                case 1: // máy = đỏ
                    result = location.row * 5 - 5;
                    break;
                case 2: // người = xanh
                    result = (7 - location.row) * 5 - 5;
                    break;
            }

            return result;
        }
    }
}
