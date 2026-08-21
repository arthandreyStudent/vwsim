using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWSim.Core;

namespace VWSim
{
    public partial class AgentSimulationPanel : UserControl
    {
        private AgentSimulation _agentSimulation;
        private VacuumWorldRenderer _renderer;

        public AgentSimulationPanel()
        {
            InitializeComponent();

            _renderer = new VacuumWorldRenderer(350, 175); // 2x2 grid, so each cell is 175x175
        }

        public void Initialize(AgentSimulation agentSimulation)
        {
            _agentSimulation = agentSimulation;
            RenderEnvironment();
            ClearLog();
            DisplayEnvironmentState();
        }

        public void UpdateSimulationStep(SimulationStepResult result, int step)
        {
            RenderEnvironment();
            DisplayResult(result, step);
        }

        public void RenderAgentName(string agentName)
        {
            labelAgentName.Text = agentName;
        }

        public void PrintBreakLine()
        {
            int numDashes = 85; // Number of dashes for the break line
            Log(new string('-', numDashes) + System.Environment.NewLine);
        }

        public void ClearLog()
        {
            richTextBoxLog.Clear();
        }

        public void DisplayEnvironmentState()
        {
            VacuumEnvironment environment = _agentSimulation.Environment;
            Log(environment.ToString());
        }

        public void DisplayResult(SimulationStepResult result, int step)
        {
            var action = result.Action;
            var agentLoc = result.AgentLoc;
            var performance = result.AgentPerformance;

            Log($"Step {step}: Action: {action} | Location: ({agentLoc[0]}, {agentLoc[1]}) | Score: {performance}");

            RenderEnvironment();
        }

        public void RenderEnvironment()
        {
            Bitmap image = _renderer.Render(_agentSimulation.Environment);

            if (pictureBoxVacuumWorld.Image != null)
            {
                pictureBoxVacuumWorld.Image.Dispose();
            }

            pictureBoxVacuumWorld.Image = image;
        }

        public void Log(string message)
        {
            richTextBoxLog.AppendText(message + System.Environment.NewLine);
        }

        public void RenderAgentStatusOverlay(string titleText, Color textColor)
        {
            if (pictureBoxVacuumWorld.Image == null) return;

            using (Graphics g = Graphics.FromImage(pictureBoxVacuumWorld.Image))
            {
                // Draw the semi-transparent overlay mask
                // Color.FromArgb takes (Alpha, Red, Green, Blue). Alpha 180 creates the mask effect.
                using (Brush overlayBrush = new SolidBrush(Color.FromArgb(180, 0, 0, 0)))
                {
                    g.FillRectangle(overlayBrush, 0, 0, pictureBoxVacuumWorld.Width, pictureBoxVacuumWorld.Height);
                }

                using (Font textFont = new Font("Unispace", 24, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    SizeF textSize = g.MeasureString(titleText, textFont);
                    float textX = (pictureBoxVacuumWorld.Width - textSize.Width) / 2;
                    float textY = (pictureBoxVacuumWorld.Height - textSize.Height) / 2;

                    g.DrawString(titleText, textFont, textBrush, textX, textY);
                }
            }

            // Force the PictureBox to refresh and show the updated image
            pictureBoxVacuumWorld.Invalidate();
        }

    }
}
