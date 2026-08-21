using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class SimpleReflexAgent : Agent
    {
        private int _currentX = 0;
        private int _currentY = 0;

        public override object Program(Tuple<int, int, bool> percept)
        {
            var tup = percept;

            if (tup == null)
            {
                return null;
            }

            bool isDirty = tup.Item3;

            if (isDirty)
            {
                return AgentAction.Suck;
            }

            _currentX = tup.Item1;
            _currentY = tup.Item2;

            bool canMoveUp = _currentX > 0;
            bool canMoveDown = _currentX < 1;
            bool canMoveLeft = _currentY > 0;
            bool canMoveRight = _currentY < 1;

            if (canMoveUp && canMoveRight)
            {
                return AgentAction.MoveUp;
            }
            else if (canMoveDown && canMoveRight)
            {
                return AgentAction.MoveRight;   
            }
            else if (canMoveDown && canMoveLeft)
            {
                return AgentAction.MoveDown;
            }
            else if (canMoveUp && canMoveLeft)
            {
                return AgentAction.MoveLeft;
            }
            else if (canMoveUp)
            {
                return AgentAction.MoveUp;
            }
            else if (canMoveDown)
            {
                return AgentAction.MoveDown;
            }
            else if (canMoveLeft)
            {
                return AgentAction.MoveLeft;
            }
            else if (canMoveRight)
            {
                return AgentAction.MoveRight;
            }

            return null;

        }

        public override string GetThought(Tuple<int, int, bool> percept, string executedAction)
        {
            bool isDirty = percept.Item3;

            if (isDirty) 
            {
                return "[THOUGHT] Percept: Dirt Detected! Sensor triggered. Executing SUCK...";
            }

            return $"[THOUGHT] Percept: Cell is clean. Standard rule triggered: Move to adjacent square...: {executedAction}";
        }

        public override string GetCompletionThought(bool completedOnOwn)
        {
            return "[THOUGHT] Step limit reached. \nI cannot retain history or know if dirt exists elsewhere.";
        }

    }
}
