using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using MChess.Class;

namespace MChess
{
    public class MBoard
    {
        public MChessPiece[,] square;

        public MBoard()
        {
            square = new MChessPiece[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    square[i, j] = new MChessPiece();

            // Khởi tạo quân 1 = máy = đỏ
            square[0, 0] = new MRookPiece(1);
            square[0, 7] = new MRookPiece(1);

            square[0, 1] = new MKnightPiece(1);
            square[0, 6] = new MKnightPiece(1);

            square[0, 2] = new MBishopPiece(1);
            square[0, 5] = new MBishopPiece(1);

            square[0, 4] = new MKingPiece(1);
            square[0, 3] = new MQueenPiece(1);

            for (int i = 0; i < 8; i++)
                square[1, i] = new MPawnPiece(1);

            // Khởi tạo quân 2 = người = xanh
            square[7, 0] = new MRookPiece(2);
            square[7, 7] = new MRookPiece(2);

            square[7, 1] = new MKnightPiece(2);
            square[7, 6] = new MKnightPiece(2);

            square[7, 2] = new MBishopPiece(2);
            square[7, 5] = new MBishopPiece(2);

            square[7, 4] = new MKingPiece(2);
            square[7, 3] = new MQueenPiece(2);

            for (int i = 0; i < 8; i++)
                square[6, i] = new MPawnPiece(2);
        }

        /// <summary>
        /// Hàm ước lượng
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public int Evaluation(short side)
        {
            short otherSide = 1;
            if(side == 1)
                otherSide = 2;

            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    MyPoint myPoint = new MyPoint(i, j);

                    if (square[i,j].side == side)
                        result += square[i, j].GetWeight(myPoint);
                    else
                        if (square[i, j].side == otherSide)
                            result -= square[i, j].GetWeight(myPoint);
                }
            }

            return result;
        }

        /// <summary>
        /// Tạo một nước đi
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentPoint"></param>
        /// <param name="nextPoint"></param>
        /// <returns></returns>
        public MBoard Move(MBoard board, MyPoint currentPoint, MyPoint nextPoint)
        {
            MBoard nextBoard = new MBoard();
            
            for(int i=0; i<8; i++)
                for (int j = 0; j < 8; j++)
                {
                    nextBoard.square[i, j] = board.square[i, j];
                }
                

            nextBoard.square[nextPoint.row, nextPoint.col].hasMoved = true;
            nextBoard.square[nextPoint.row, nextPoint.col] = board.square[currentPoint.row, currentPoint.col];

            // Phong hậu
            if (nextBoard.square[nextPoint.row, nextPoint.col].side == 1 &&
                nextPoint.row == 7 &&
                nextBoard.square[nextPoint.row, nextPoint.col].name == "Pawn")
            {
                nextBoard.square[nextPoint.row, nextPoint.col] = new MQueenPiece(1);
            }

            nextBoard.square[currentPoint.row, currentPoint.col] = new MChessPiece();
            
            return nextBoard;
        }

        /// <summary>
        /// Tạo tất cả các nước đi có thể
        /// </summary>
        /// <param name="board"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public ArrayList GenerateAllPosibleMove(MBoard board, short side)
        {
            ArrayList allPosibleMove = new ArrayList();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    MChessPiece p = square[i, j];
                    MyPoint myPoint = new MyPoint();
                    myPoint.row = i;
                    myPoint.col = j;

                    if (p.side == side) // máy = đỏ
                    {
                        ArrayList myArray = p.GenerateLegalMove(myPoint, board);
                        foreach (MyPoint point in myArray)
                        {
                            MBoard myBoard = Move(board, myPoint, point);
                            allPosibleMove.Add(myBoard);
                        }
                    }
                }
            }

            return allPosibleMove;
        }

        /// <summary>
        /// Chọn bàn làm hàm ước lượng MAX
        /// </summary>
        /// <param name="allPosibleMove"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public int ChooseMax(ArrayList allPosibleMove, short side)
        {
            int res = 0;
            MBoard chosenBoard = (MBoard)allPosibleMove[res];
            int max = chosenBoard.Evaluation(side);

            for (int i = 1; i < allPosibleMove.Count; i++)
            {
                MBoard tmpBoard = (MBoard)allPosibleMove[i];
                int tmp = tmpBoard.Evaluation(side);
                if (tmp > max)
                {
                    max = tmp;
                    res = i;
                }
            }

            return res;
        }

        /// <summary>
        /// Chọn bàn làm hàm ước lượng MIN
        /// </summary>
        /// <param name="allPosibleMove"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public int ChooseMin(ArrayList allPosibleMove, short side)
        {
            int res = 0;
            MBoard chosenBoard = (MBoard)allPosibleMove[res];
            int min = chosenBoard.Evaluation(side);

            for (int i = 1; i < allPosibleMove.Count; i++)
            {
                MBoard tmpBoard = (MBoard)allPosibleMove[i];
                int tmp = tmpBoard.Evaluation(side);
                if (tmp < min)
                {
                    min = tmp;
                    res = i;
                }
            }

            return res;
        }

        /// <summary>
        /// Máy đánh
        /// </summary>
        /// <returns></returns>
        public MBoard ComputerMove()
        {
            MBoard computerMove1 = new MBoard();

            // Bước 1
            ArrayList firstMove = GenerateAllPosibleMove(this, 1);

            ArrayList firstMove2 = new ArrayList();

            for(int j=0; j<firstMove.Count; j++)
            {
                ArrayList secondMove = GenerateAllPosibleMove((MBoard)firstMove[j], 2);

                ArrayList secondMove2 = new ArrayList();

                for(int i=0; i<secondMove.Count; i++)
                {
                    ArrayList thirdMove = GenerateAllPosibleMove((MBoard)secondMove[i], 1);

                    secondMove2.Add(thirdMove[ChooseMax(thirdMove, 1)]);   
                }

                firstMove2.Add(secondMove2[ChooseMin(secondMove2, 1)]);
            }

            // Bước 2
            computerMove1 = (MBoard)firstMove[ChooseMax(firstMove2, 1)];

            return computerMove1;
        }
    }
}
