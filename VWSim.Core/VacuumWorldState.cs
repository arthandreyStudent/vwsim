using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public class VacuumWorldState
    {

        public int[,] Grid { get; }
        public List<Dirt> Dirts { get; }

        public int AgentX { get; }
        public int AgentY { get; }

        public VacuumWorldState(int[,] grid, List<Dirt> dirts, int agentX, int agentY)
        {
            Grid = grid;
            Dirts = dirts;
            AgentX = agentX;
            AgentY = agentY;
        }

    }
}
