using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public class SimulationStepResult
    {
        public string Action { get; }
        public int[] AgentLoc {  get; }
        public int AgentPerformance { get; }

        public SimulationStepResult(string action, int[] agentLoc, int agentPerformance)
        {
            Action = action;
            AgentLoc = agentLoc;
            AgentPerformance = agentPerformance;
        }

    }
}
