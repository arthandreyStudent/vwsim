using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VWSim.Core
{
    public class ModelBasedReflexAgent : Agent
    {
        private (int x, int y) _currentPos = (0, 0);

        private string _lastAction = null;

        // Memory of this model-based reflex agent
        private readonly Dictionary<(int x, int y), bool> _worldModel = new Dictionary<(int x, int y), bool>();

        // Boundaries coordinate that the agent discovers through movement attempts
        private int? _minX, _maxX, _minY, _maxY;

        public override object Program(Tuple<int, int, bool> percept)
        {
            int sensedX = percept.Item1;
            int sensedY = percept.Item2;
            bool isDirty = percept.Item3;

            // Only record a boundary hit if the last action was a movement that failed to change coordinates
            bool isMoveAction = _lastAction != AgentAction.Suck && _lastAction != AgentAction.NoOp;

            // Record if a move failed (either agent hit a boundary/wall)
            if (_lastAction != null && isMoveAction && (sensedX, sensedY) == _currentPos)
            {
                RecordBoundaryHit(_lastAction, _currentPos);
            }

            _currentPos = (sensedX, sensedY);

            _worldModel[_currentPos] = isDirty;

            if (IsEnvironmentFullyExploredAndClean())
            {
                this.AmIDoneCleaningAllDirtyCells = true;
                return AgentAction.NoOp;
            }

            if (isDirty)
            {
                _lastAction = AgentAction.Suck;
                return AgentAction.Suck;
            }

            _lastAction = ChooseNextExplorationMove();

            return _lastAction;
        }

        private void RecordBoundaryHit(string action, (int x, int y) pos)
        {
            // Infer grid boundary relative to the current coordinates
            switch (action)
            {
                case AgentAction.MoveLeft: _minY = pos.y; break;
                case AgentAction.MoveRight: _maxY = pos.y; break;
                case AgentAction.MoveUp: _minX = pos.x; break;
                case AgentAction.MoveDown: _maxX = pos.x; break;
            }
        }

        private bool IsEnvironmentFullyExploredAndClean()
        {
            // Can't be done if agent still have memory of dirty cells
            if (_worldModel.Values.Any(isDirty => isDirty))
            {
                return false;
            }

            // Can't be done if agent haven't mapped all 4 boundaries yet
            if (!_minX.HasValue || !_maxX.HasValue || !_minY.HasValue || !_maxY.HasValue)
            {
                return false;
            }

            // Calculate total expected grid volume from discovered bounds
            int expectedTotalCells = (_maxX.Value - _minX.Value + 1) * (_maxY.Value - _minY.Value + 1);
            
            // Truly done when visited cells match discovered grid volume AND all are clean
            return _worldModel.Count == expectedTotalCells;
        }

        private bool CanMove(string action)
        {
            switch (action)
            {
                case AgentAction.MoveRight: return !_maxY.HasValue || _currentPos.y < _maxY.Value;
                case AgentAction.MoveLeft: return !_minY.HasValue || _currentPos.y > _minY.Value;
                case AgentAction.MoveDown: return !_maxX.HasValue || _currentPos.x < _maxX.Value;
                case AgentAction.MoveUp: return !_minX.HasValue || _currentPos.x > _minX.Value;

                default: return false;
            }
        }

        private bool IsOppositeMove(string moveA, string moveB)
        {
            if (moveA == AgentAction.MoveRight && moveB == AgentAction.MoveLeft) return true;
            if (moveA == AgentAction.MoveLeft && moveB == AgentAction.MoveRight) return true;
            if (moveA == AgentAction.MoveUp && moveB == AgentAction.MoveDown) return true;
            if (moveA == AgentAction.MoveDown && moveB == AgentAction.MoveUp) return true;

            return false;
        }

        private string ChooseNextExplorationMove()
        {
            // Checking Right
            if (CanMove(AgentAction.MoveRight) && 
                !_worldModel.ContainsKey((_currentPos.x, _currentPos.y + 1)) && 
                _lastAction != AgentAction.MoveLeft)
            {
                return AgentAction.MoveRight;
            }

            // Checking Down
            if (CanMove(AgentAction.MoveDown) && 
                !_worldModel.ContainsKey((_currentPos.x + 1, _currentPos.y)) && 
                _lastAction != AgentAction.MoveUp)
            {
                return AgentAction.MoveDown;
            }

            // Checking Left
            if (CanMove(AgentAction.MoveLeft) && 
                !_worldModel.ContainsKey((_currentPos.x, _currentPos.y - 1)) && 
                _lastAction != AgentAction.MoveRight)
            {
                return AgentAction.MoveLeft;
            }

            // Checking Up
            if (CanMove(AgentAction.MoveUp) && 
                !_worldModel.ContainsKey((_currentPos.x - 1, _currentPos.y)) && 
                _lastAction != AgentAction.MoveDown)
            {
                return AgentAction.MoveUp;
            }

            // Fallback: Cycle through directions, respecting known boundaries
            string[] directionalCycle = { AgentAction.MoveDown, AgentAction.MoveLeft, AgentAction.MoveUp, AgentAction.MoveRight };

            foreach (var dir in directionalCycle)
            {
                if (CanMove(dir) && !IsOppositeMove(dir, _lastAction))
                {
                    return dir;
                }
            }

            return AgentAction.NoOp; // Safest fallback if completely boxed in
        }

        public override string GetThought(Tuple<int, int, bool> percept, string executedAction)
        {
            bool isDirty = percept.Item3;

            if (executedAction == AgentAction.NoOp)
            {
                return "[THOUGHT] Memory verified: All cells explored. \n0 dirty cells remaining.";
            }

            if (isDirty) 
            {
                return "[THOUGHT] Percept: Dirt Detected! Recording position to memory and cleaning...";
            }

            return $"[THOUGHT] Analyzing memory map... Navigating to unexplored cell...: {executedAction}";
        }

        public override string GetCompletionThought(bool completedOnOwn)
        {
            if (completedOnOwn)
            {
                return "[THOUGHT] Memory verified: All cells explored & clean. \nMy job is done here!";
            }

            return "[THOUGHT] Step limit reached before full map verification was completed.";
        }


    }
}
