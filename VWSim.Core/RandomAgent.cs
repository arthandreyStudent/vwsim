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

            return Agent.AllActions[_rand.Next(Agent.AllActions.Count)];
        }
    }
}
