using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class Dirt
    {
        public int Row { get; }
        public int Col { get; }

        public int OffsetX { get; }
        public int OffsetY { get; }

        public Dirt(int row, int col, int offsetX, int offsetY)
        {
            Row = row;
            Col = col;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

    }
}
