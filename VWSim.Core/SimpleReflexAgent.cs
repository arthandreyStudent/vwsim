using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWSim.Core
{
    public class SimpleReflexAgent : Agent
    {

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

            int x = tup.Item1;
            int y = tup.Item2;

            bool canMoveUp = x > 0;
            bool canMoveDown = x < 1;
            bool canMoveLeft = y > 0;
            bool canMoveRight = y < 1;

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

    }
}
