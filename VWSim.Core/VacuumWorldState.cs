using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public class VacuumWorldState
    {
        public int[,] Grid { get; }
        public List<Dirt> Dirts { get; }

        public VacuumWorldState(int[,] grid, List<Dirt> dirts)
        {
            Grid = grid;
            Dirts = dirts;
        }

    }
}
