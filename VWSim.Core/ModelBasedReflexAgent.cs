using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public class ModelBasedReflexAgent : Agent
    {
        private int _currentX = 0;
        private int _currentY = 0;

        private string _lastAction = null;

        // Memory of this model-based reflex agent
        private readonly Dictionary<(int x, int y), bool> _worldModel = new Dictionary<(int x, int y), bool>();

        public override object Program(Tuple<int, int, bool> percept)
        {
            UpdatePositionFromLastAction();

            int sensorX = percept.Item1;
            int sensorY = percept.Item2;
            bool isDirty = percept.Item3;

            _currentX = sensorX;
            _currentY = sensorY;

            // Update the world model with the current percept
            _worldModel[(_currentX, _currentY)] = isDirty;

            string chosenAction = null;

            if (isDirty)
            {
                chosenAction = AgentAction.Suck;
            }
            else
            {
                chosenAction = ChooseNextMove();
            }

            // Store the chosen action for the next iteration
            _lastAction = chosenAction;

            return chosenAction;
        }

        private void UpdatePositionFromLastAction()
        {
            if (string.IsNullOrEmpty(_lastAction))
            {
                return;
            }

            switch (_lastAction)
            {
                case AgentAction.MoveRight:
                    _currentY++;
                    break;
                case AgentAction.MoveLeft:
                    _currentY--;
                    break;
                case AgentAction.MoveUp:
                    _currentX--;
                    break;
                case AgentAction.MoveDown:
                    _currentX++;
                    break;
            }
        }

        private string ChooseNextMove()
        {
            if (_worldModel.TryGetValue((_currentX, _currentY + 1), out bool rightDirty) && rightDirty)
            {
                return AgentAction.MoveRight;
            }
            else if (_worldModel.TryGetValue((_currentX, _currentY - 1), out bool leftDirty) && leftDirty)
            {
                return AgentAction.MoveLeft;
            }
            else if (_worldModel.TryGetValue((_currentX - 1, _currentY), out bool upDirty) && upDirty)
            {
                return AgentAction.MoveUp;
            }
            else if (_worldModel.TryGetValue((_currentX + 1, _currentY), out bool downDirty) && downDirty)
            {
                return AgentAction.MoveDown;
            }

            // Fallback if no adjacent dirty squares are found, move right by default
            return AgentAction.MoveRight;
        }

    }
}
