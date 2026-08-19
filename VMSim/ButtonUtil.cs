using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMSim
{
    public static class ButtonUtil
    {
        public static void SetButtonState(Button button, bool isEnabled)
        {
            button.Enabled = isEnabled;
        }
    }
}
