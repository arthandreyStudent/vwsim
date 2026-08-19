using VWSim.Core;

namespace VWSimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VacuumWorldGenerator Generator = new VacuumWorldGenerator();

            VacuumWorldState InitialState = Generator.Generate();

            VacuumEnvironment RandomEnv = new VacuumEnvironment(InitialState);
            VacuumEnvironment SfaEnv = new VacuumEnvironment(InitialState);

            Agent RandomAgent = new RandomAgent();
            Agent SFAgent = new SimpleReflexAgent();

            AgentSimulation RandomSimulation = new AgentSimulation(RandomEnv, RandomAgent, "Random Agent Simulation");
            AgentSimulation SfaSimulation = new AgentSimulation(SfaEnv, SFAgent, "Simple Reflex Agent Simulation");

            List<AgentSimulation> Simulations = new List<AgentSimulation> { RandomSimulation, SfaSimulation };

            VacuumSimulation Simulation = new VacuumSimulation(Simulations);

            int steps = 10;


            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                Console.WriteLine(RandomEnv);
                Console.WriteLine(SfaEnv);
                Simulation.RunStep();  
            }

        }
    }
}