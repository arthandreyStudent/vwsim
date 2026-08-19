using System;
using System.Collections.Generic;
using System.Text;

namespace VWSim.Core
{
    public class VacuumWorldGenerator
    {
        private readonly Random _rand;

        public VacuumWorldGenerator()
        {
            _rand = new Random();
        }

        public VacuumWorldState Generate()
        {
            int[,] grid = new int[2, 2];
            List<Dirt> dirts = new List<Dirt>();

            // Generate grid with random dirt positions
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    grid[row, col] = _rand.Next(0, 2); // 0 for clean, 1 for dirty
                }
            }

            // Generate Dirt objects
            int dirtRandomOffset = 25;

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    int offsetX = _rand.Next(-dirtRandomOffset, dirtRandomOffset + 1);
                    int offsetY = _rand.Next(-dirtRandomOffset, dirtRandomOffset + 1);

                    if (grid[row, col] == 1)
                    {
                        dirts.Add(new Dirt(row, col, offsetX, offsetY));
                    }
                }
            }

            return new VacuumWorldState(grid, dirts, 0, 0); // Agent starts at (0, 0)
        }

    }
}
