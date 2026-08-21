using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public static class AgentPositionGenerator
    {
        private static Random _random = new Random();

        private const int AgentMinX = 0;
        private const int AgentMaxX = 1;
        private const int AgentMinY = 0;
        private const int AgentMaxY = 1;

        public static int[] GeneratePosition()
        {
            int x = _random.Next(AgentMinX, AgentMaxX + 1);
            int y = _random.Next(AgentMinY, AgentMaxY + 1);
            return new int[] { x, y };
        }
    }
}
