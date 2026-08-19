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
                return "Suck";
            }

            int x = tup.Item1;
            int y = tup.Item2;

            bool canMoveUp = x > 0;
            bool canMoveDown = x < 1;
            bool canMoveLeft = y > 0;
            bool canMoveRight = y < 1;

            if (canMoveUp && canMoveRight)
            {
                return "Up";
            }
            else if (canMoveDown && canMoveRight)
            {
                return "Right";   
            }
            else if (canMoveDown && canMoveLeft)
            {
                return "Down";
            }
            else if (canMoveUp && canMoveLeft)
            {
                return "Left";
            }
            else if (canMoveUp)
            {
                return "Up";
            }
            else if (canMoveDown)
            {
                return "Down";
            }
            else if (canMoveLeft)
            {
                return "Left";
            }
            else if (canMoveRight)
            {
                return "Right";
            }

            return null;

        }

    }
}
