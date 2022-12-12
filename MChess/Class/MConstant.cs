using System;
using System.Collections.Generic;
using System.Text;

namespace MChess
{
    public struct MyPoint
    {
        public int row;
        public int col;

        public MyPoint(int r, int c)
        {
            row = r;
            col = c;
        }
    }

    class MConstant
    {
        public static string GetPath()
        {
            string path;
            
            path = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            path = path.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].Name, "");

            return path;
        }
    }
}
