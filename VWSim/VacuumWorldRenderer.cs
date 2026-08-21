using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VWSim.Core;

namespace VWSim
{
    public class VacuumWorldRenderer
    {
        private readonly int _pictureBoxSize;
        private readonly int _cellSize;

        public VacuumWorldRenderer(int pictureBoxSize, int cellSize)
        {
            _pictureBoxSize = pictureBoxSize;
            _cellSize = cellSize;
        }

        public Bitmap Render(VacuumEnvironment env)
        {
            Bitmap bitmap = new Bitmap(_pictureBoxSize, _pictureBoxSize);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                DrawGrid(g);
                DrawAgent(env, g);
                DrawDirt(env, g);
            }

            return bitmap;
        }

        private void DrawGrid(Graphics g)
        {
            g.Clear(Color.Black);

            using (Pen gridPen = new Pen(Color.White, 2))
            {
                // Draw horizontal line dividing top and bottom rows
                g.DrawLine(gridPen, 0, _cellSize, _pictureBoxSize, _cellSize);

                // Draw vertical line dividing left and right columns
                g.DrawLine(gridPen, _cellSize, 0, _cellSize, _pictureBoxSize);
            }
        }

        private void DrawAgent(VacuumEnvironment env, Graphics g)
        {
            int[] agentLoc = env.AgentLoc();

            int agentY = agentLoc[0];
            int agentX = agentLoc[1];

            /*
             * Adjust the offset multiplier to control how far the agent is from the top-left corner of the cell.
             * Positive offsetX = move right, Negative offsetX = move left
             * Positive offsetY = move down, Negative offsetY = move up
             */
            int offsetXMultiplier = -14;
            int offsetYMultiplier = -14;

            int centerX = agentX * _cellSize + _cellSize / 2 + offsetXMultiplier;
            int centerY = agentY * _cellSize + _cellSize / 2 + offsetYMultiplier;

            int radius = 20;

            using (Brush agentBrush = new SolidBrush(Color.Red))
            {
                g.FillEllipse(agentBrush, 
                              centerX - radius, 
                              centerY - radius, 
                              radius * 2, 
                              radius * 2);
            }
        }

        private void DrawDirt(VacuumEnvironment env, Graphics g)
        {
            int rows = env.Grid.GetLength(0);
            int cols = env.Grid.GetLength(1);

            Brush dirtBrush = new SolidBrush(Color.Sienna);

            int dirtWidth = 8;
            int dirtHeight = 8;

            int constantOffsetX = 20; // Adjust this value to control the distance of dirt from the center of the cell
            int constantOffsetY = 20; // Adjust this value to control the distance of dirt from the center of the cell

            List<Dirt> dirts = env.Dirts;

            foreach (Dirt dirt in dirts)
            {
                int centerX = dirt.Col * _cellSize + _cellSize / 2 + dirt.OffsetX + constantOffsetX;
                int centerY = dirt.Row * _cellSize + _cellSize / 2 + dirt.OffsetY + constantOffsetY;

                g.FillEllipse(dirtBrush,
                              centerX - dirtWidth / 2,
                              centerY - dirtHeight / 2,
                              dirtWidth,
                              dirtHeight);
            }

            dirtBrush.Dispose();
        }

    }
}
