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
        public const string NoOp = "NoOp";
    }

    public abstract class Agent
    {
        public static readonly List<string> AllActions = new List<string>
        {
            AgentAction.Suck,
            AgentAction.MoveUp,
            AgentAction.MoveDown,
            AgentAction.MoveLeft,
            AgentAction.MoveRight,
            AgentAction.NoOp
        };

        public bool AmIDoneCleaningAllDirtyCells { get; set; } = false;

        public abstract object Program(Tuple<int, int, bool> percept);
        public int Performance { get; set; } = 0;

        public virtual string GetThought(Tuple<int, int, bool> percept, string executedAction)
        {
            return string.Empty;
        }

        public virtual string GetCompletionThought(bool completedOnOwn)
        {
            return completedOnOwn
                ? "[THOUGHT] I have verified my work and completed the objective."
                : "[THOUGHT] Max step limit reached.";
        }

    }
}
