using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Append.AntDesign.Core
{
    public struct Offset
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Offset(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Offset Create(int x, int y)
        {
            return new Offset(x, y);
        }
    }
}
