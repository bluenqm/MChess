using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace MChess
{
    public class MChessPiece
    {
        public string name;
        public bool hasMoved;
        public bool isCaptuable;
        public short side;

        public MChessPiece()
        {
            name = "";
            hasMoved = false;
            isCaptuable = false;
            side = 0;
        }

        public MChessPiece(string pieceName, short pieceSide)
        {
            name = pieceName;
            hasMoved = false;
            isCaptuable = false;
            side = pieceSide;
        }

        public virtual ArrayList GenerateLegalMove(MyPoint location, MBoard board)
        {
            ArrayList legalMove = new ArrayList();

            return legalMove;
        }

        public virtual int GetWeight(MyPoint location)
        {
            return 0;
        }
    }
}
