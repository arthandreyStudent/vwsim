using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class RandomAgent : Agent
    {
        private readonly Random _rand = new Random();
        public override object Program(Tuple<int, int, bool> percept)
        {
            var tup = percept;

            if (tup == null)
            {
                return null;
            }

            bool isDirty = tup.Item3;

            if (isDirty)
            {
                return AgentAction.Suck;
            }

            return Agent.AllActions[_rand.Next(1, Agent.AllActions.Count - 1)];
        }

        public override string GetThought(Tuple<int, int, bool> percept, string executedAction)
        {
            bool isDirty = percept.Item3;

            if (isDirty)
            {
                return "[THOUGHT] Percept: Dirt Detected! Sensor triggered. Executing SUCK...";
            }

            return $"[THOUGHT] Percept: Cell is clean. Selecting random movement from available set...: {executedAction}";
        }

        public override string GetCompletionThought(bool completedOnOwn)
        {
            return "[THOUGHT] Step limit reached. I react to dirt when seen, \nbut I wander blindly with no memory or map.";
        }
    }
}
