using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class AgentSimulation
    {
        public Agent Agent { get; }
        public VacuumEnvironment Environment { get; }

        public string Name { get; }

        public AgentSimulation (VacuumEnvironment environment, Agent agent, string name)
        {
            Agent = agent;
            Environment = environment;
            Name = name;
        }
        
        public SimulationStepResult RunStep()
        {
            var percept = Environment.Percept(Agent);
            var action = Agent.Program(percept) as string;
            Environment.ExecuteAction(Agent, action);

            return new SimulationStepResult(action, Environment.AgentLoc(), Agent.Performance);
        }
    }
}
