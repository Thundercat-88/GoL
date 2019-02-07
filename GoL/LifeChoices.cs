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
        //Values for the aray have to be equal as its a multidimensional array, and not a jagged one!
        int height = 25;
        int width = 25;
        bool[,] cell;
        bool[,] nextGenCell;
      
        //Method to ask the type of game that the user would like to see
        public int InitialiseGame()
        {
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Random game");
            Console.WriteLine("2. Blinker");
            Console.WriteLine("2. Glider");
            int gametype;
            // Get user input
            ConsoleKeyInfo UserInput = Console.ReadKey(); 
            if (char.IsDigit(UserInput.KeyChar))
            {
                // Parse the input string to an integer
                gametype = int.Parse(UserInput.KeyChar.ToString()); 
            }
            else
            {
                gametype = 1; 
            }
            Console.Clear();
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
        public void BlinkerGeneration()
        {
            cell = new bool[height, width];
            nextGenCell = new bool[height, width];

            cell[10, 10] = true;
            cell[10, 11] = true;
            cell[10, 12] = true;
        }

        public void GliderGeneration()
        {
            cell = new bool[height, width];
            nextGenCell = new bool[height, width];

            cell[10, 10] = true;
            cell[11, 10] = true;
            cell[12, 10] = true;
            cell[12, 9] = true;
            cell[11, 8] = true;

        }

        //Method to make the array infinate, it replaces the edge with the opposite edge
        private void EdgeWrap(ref int x, ref int y)
        {
            if (x < 0)
            {
                x += width;
            }
            else if (x > width - 1)
            {
                x -= width;
            }
            if (y < 0)
            {
                y += height;
            }
            else if (y > height - 1)
            {
                y -= height;
            }
        }
        //Method to count alive cells around the main cell, ignoring the cell on [0,0] in the array
        //This method will need to be used within a for loop when drawing the game on the console
        private int AliveNeighbours(int row, int col)
        {
            int CountNeighbours = 0;
            for (int i = row - 1; i < row + 2; i++)
            {
               for (int j = col - 1; j < col +2; j++)
               {
                    int x1 = i;
                    int y1 = j;
                    if (!((i == row) && (j == col)))   
                    {
                        //Call EdgeWrap and replace values if at edge of the array
                        EdgeWrap(ref x1, ref y1);
                        //If the cell value is true, increment count
                        if (cell[x1, y1] == true)
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
                        //Underpopulation   
                        if (alive < 2)
                        {
                            nextGenCell[i, j] = false;
                        }
                        //Next Generation
                        if (alive == 2 || alive == 3)
                        {
                            nextGenCell[i, j] = true;
                        }
                        //Overpopulation
                        if (alive > 3)
                        {
                            nextGenCell[i, j] = false;
                        }
                    }
                    //Reproduction
                    if (cell[i, j] == false && alive == 3)
                    {
                       nextGenCell[i, j] = true;
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
                    Console.Write(cell[i, j] ? " x " : " - ");
                }
                Console.WriteLine();               
            }
            //Slow the game down to a more reasonable speed
            System.Threading.Thread.Sleep(600);
        }

        //Method to update the cell array with the newly generated nextGenCell array
        public void UpdateLife()
        {
            Array.Copy(nextGenCell, cell,nextGenCell.Length);           
        }

        //This method calls the above method to start the game
        public void GameStart()
        {
            WriteLife();
            NextGeneration();
            UpdateLife();
        }

    }
}
