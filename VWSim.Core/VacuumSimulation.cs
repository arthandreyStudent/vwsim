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

        public List<SimulationStepResult> RunStep()
        {
            var results = new List<SimulationStepResult>();

            foreach (var agentSimulation in _agentSimulations)
            {
                SimulationStepResult result = agentSimulation.RunStep();
                results.Add(result);
            }

            return results;
        }
        
    }
}
