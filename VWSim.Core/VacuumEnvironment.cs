using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class VacuumEnvironment : Environment
    {
        // 2x2 grid representing the vacuum environment: 1 - dirty, 0 - clean
        private int[,] _grid = new int[2, 2];

        private List<Dirt> _dirts = new List<Dirt>();

        private int _agentX;
        private int _agentY;

        public int TotalDirtCount { get; }
        public int TotalCleanedCount { get; set; } = 0;

        public VacuumEnvironment(VacuumWorldState initialState)
        {
            _grid = initialState.Grid.Clone() as int[,];

            _dirts = initialState.Dirts.Select(d => new Dirt(d.Row, d.Col, d.OffsetX, d.OffsetY)).ToList();

            _agentX = initialState.AgentX;
            _agentY = initialState.AgentY;

            TotalDirtCount = _dirts.Count;
        }

        public int[,] Grid => _grid;
        
        public List<Dirt> Dirts => _dirts;

        public bool IsDirty(int x, int y)
        {
            return _grid[x, y] == 1;
        }

        public bool IsAllCleaned()
        {
            return _dirts.Count == 0;
        }

        private void CleanCell(int x, int y)
        {
            _grid[x, y] = 0; // Mark the cell as clean

            // Remove the corresponding dirt object from the list
            _dirts.RemoveAll(d => d.Row == x && d.Col == y);

            TotalCleanedCount++;
        }

        public int[] AgentLoc()
        {
            return new int[] { _agentX, _agentY };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vacuum Environment Grid State:");

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    sb.Append(_grid[row, col] + " ");
                }
                sb.AppendLine();
            }

            sb.AppendLine();

            sb.AppendLine($"Agent Position: ({_agentX}, {_agentY})");
            
            return sb.ToString();
        }

        public override void ExecuteAction(Agent agent, string action)
        {
            // Implementation for executing actions in the vacuum environment
            string act = action as string;

            if (act == null)
            {
                agent.Performance -= 1; // Penalize for invalid action
                return;
            }

            if (act.Equals("Suck"))
            {
                if (IsDirty(_agentX, _agentY))
                {
                    agent.Performance += 10; // Reward for cleaning
                    CleanCell(_agentX, _agentY);
                }
            }
            else if (act.Equals("Up") && _agentX > 0)
            {
                _agentX--;
                agent.Performance -= 1; // Cost for moving
            }
            else if (act.Equals("Down") && _agentX < 1)
            {
                _agentX++;
                agent.Performance -= 1; // Cost for moving
            }
            else if (act.Equals("Left") && _agentY > 0)
            {
                _agentY--;
                agent.Performance -= 1; // Cost for moving
            }
            else if (act.Equals("Right") && _agentY < 1)
            {
                _agentY++;
                agent.Performance -= 1; // Cost for moving
            }
            else
            {
                agent.Performance -= 1; // Penalize for invalid action
            }
        }

        public override Tuple<int, int, bool> Percept(Agent agent)
        {
            // Implementation for perceiving the environment
            bool isDirty = _grid[_agentX, _agentY] == 1;

            return Tuple.Create<int, int, bool>(_agentX, _agentY, isDirty);
        }
    }
}
