using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSim
{
    public abstract class Environment
    {
        public abstract void ExecuteAction(Agent agent, string action);
        public abstract Tuple<int, int, bool> Percept(Agent agent);
    }
}
