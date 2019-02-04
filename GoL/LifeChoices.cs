using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    class LifeChoices
    {
        //Declare all variables that need to be used within the program, 
        //along with a random method and a multi dimensional array
        int height = 20;
        int width = 50;
        bool[,] cell;
        bool[,] nextGenCell;
        int x = 0;
        int y = 0;

        //Fill the multi dimensional array with random boolean values using the Random method
        public void FirstGeneration()
        {
            cell = new bool[height, width];          
            nextGenCell = new bool[height, width];
            Random DOA = new Random();
            for (x = 0; x < height; x++)
            {
                for (y = 0; y < width; y++)
                {
                    cell[x, y] = DOA.NextDouble() >= 0.5;
                }
            }
        }

        //Method to count alive cells around the main cell, ignoring the cell on [0,0] in the array
        //This method will need to be used within a for loop when drawing the game on the console

        int AliveNeighbours()
        {
            //int a = Array.IndexOf(cell,x);
            //int b = Array.IndexOf(cell,y);
            int CountNeighbours = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    //
                    if (!((j < 0 || j < 0) || (i >= height || j >= width)))
                    {
                        if (cell[i, j] == true) CountNeighbours++;
                    }
                }
            }
            return CountNeighbours;
        }

        //Generate a new multi dimensional array (Next Generation) using the neighbour count for each cell in the original array
        //Compare the count of neighbours for each cell, then apply Conways rules  
        //Each cell for the new array must declare a state depending on Conways rules
        //

        public void NextGeneration()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int alive = AliveNeighbours();

                    if (cell[i, j])
                    {
                        if (alive < 2 || alive > 3)
                        {
                            nextGenCell[i, j] = false;
                        }
                        else
                        {
                            nextGenCell[i, j] = true;
                        }
                    }
                }
            }
        }
        public void WriteLife()
        {
                     
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(cell[i, j] ? "x" : " ");
                }
                Console.WriteLine();              
            }          
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        public void UpdateLife()
        {
            cell = nextGenCell;
        }

    }
}
