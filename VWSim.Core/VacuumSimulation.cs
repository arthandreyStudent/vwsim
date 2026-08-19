using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class VacuumSimulation
    {
        private List<AgentSimulation> _agentSimulations;

        public VacuumSimulation(List<AgentSimulation> agentSimulations)
        {
            _agentSimulations = agentSimulations;
        }

        public void RunStep()
        {
            foreach (var agentSimulation in _agentSimulations)
            {
                agentSimulation.RunStep();
            }
        }
        
    }
}
