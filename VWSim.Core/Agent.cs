using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public static class AgentAction
    {
        public const string Suck = "Suck";
        public const string MoveUp = "MoveUp";
        public const string MoveDown = "MoveDown";
        public const string MoveLeft = "MoveLeft";
        public const string MoveRight = "MoveRight";
    }

    public abstract class Agent
    {
        public static readonly List<string> AllActions = new List<string>
        {
            AgentAction.Suck,
            AgentAction.MoveUp,
            AgentAction.MoveDown,
            AgentAction.MoveLeft,
            AgentAction.MoveRight
        };

        public abstract object Program(Tuple<int, int, bool> percept);
        public int Performance { get; set; } = 0;
    }
}
