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
        int height = 10;
        int width = 20;
        bool[,] cell;
        bool[,] nextGenCell;
      
        //Method to ask the type of game that the user would like to see
        public int InitialiseGame()
        {
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Random game");
            Console.WriteLine("2. Pre generated game");
            int gametype;
            ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
            if (char.IsDigit(UserInput.KeyChar))
            {
                gametype = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
            }
            else
            {
                gametype = 1;  // Else we assign a default value
            }
            return gametype;
        }

        //Method to fill the multi dimensional array with random boolean values using the Random method
        public void RandomGeneration()
        {
            cell = new bool[height, width];          
            nextGenCell = new bool[height, width];
            Random DOA = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cell[i, j] = DOA.NextDouble() >= 0.5;
                }
            }
        }

        //Method to fill the multi dimensional array with pre generated values
        public void PreGeneration()
        {
            cell = new bool[height, width];
            nextGenCell = new bool[height, width];

            cell[10, 10] = true;
            cell[10, 11] = true;
            cell[10, 12] = true;
            cell[10, 13] = true;
            cell[10, 14] = true;
        }

        //Method to count alive cells around the main cell, ignoring the cell on [0,0] in the array
        //This method will need to be used within a for loop when drawing the game on the console
        private int AliveNeighbours(int row, int col)
        {
            int CountNeighbours = 0;
            for (int i = col - 1; i < col + 2; i++)
            {
                for (int j = row - 1; j < row + 2; j++)
                {
                    bool v = !(col < 0 || row < 0);
                    bool w = col > height || row > width;
                    bool x = i == 0 && j == 0;

                    if (v || w || x)                   
                    {
                        if (cell[i, j] == true)
                        {
                            CountNeighbours++;
                        }
                    }                 
                }
            }
            return CountNeighbours;
        }

        //Generate a new multi dimensional array (Next Generation) using the neighbour count for each cell in the original array
        //Compare the count of neighbours for each cell, then apply Conways rules  
        //Each cell for the new array must declare a state depending on Conways rules

        public void NextGeneration()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int alive = AliveNeighbours(i,j);

                    if (cell[i, j])
                    {                       
                           
                        if (alive == 2 || alive == 3)
                        {
                            nextGenCell[i, j] = true;
                        }
                        else
                        {
                           nextGenCell[i, j] = false;
                        }
                    }
                }
            }
        }

        //Method to write the values in the array to the console
        public void WriteLife()
        {                    
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(cell[i, j] ? "x" : "-");
                }
                Console.WriteLine();              
            }          
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        //Method to update the cell array with the newly generated nextGenCell array
        public void UpdateLife()
        {
            //cell = nextGenCell;
            Array.Copy(nextGenCell, cell,cell.Length);
        }

    }
}
