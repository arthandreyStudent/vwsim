using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSim
{
    public abstract class Agent
    {
        public abstract object Program(Tuple<int, int, bool> percept);
        public int Performance { get; set; } = 0;
    }
}
