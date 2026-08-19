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
        
        public void RunStep()
        {
            var percept = Environment.Percept(Agent);
            var action = Agent.Program(percept) as string;
            Environment.ExecuteAction(Agent, action);

            var tup = percept;

            string locationText = "(?, ?)";

            if (tup != null)
            {
                locationText = $"({tup.Item1}, {tup.Item2})";
            }

            Console.WriteLine($"Agent: {Name} | Action: {action} | Location: {locationText} | Performance: {Agent.Performance}");
        }
    }
}
