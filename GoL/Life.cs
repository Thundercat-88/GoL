using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    public class Life
    {
        static void Main(string[] args)
        {
            //New instance of Lifechoice class
            LifeChoices LC = new LifeChoices();

            //Ask for type of game          
            int gametype = LC.InitialiseGame();
            int generation = 0;
            //Switch statement to configure the game board
            switch (gametype)
            {
                case 1:
                    {
                        do
                        {
                            //This uses the random method to generate the first generation
                            LC.RandomGeneration();
                            while (!Console.KeyAvailable)
                            {
                                Console.SetCursorPosition(0, Console.WindowTop);
                                generation++;
                                LC.GameStart();
                                Console.WriteLine("Generation = " + generation);
                                Console.WriteLine("Press ESC to stop");
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                        break;
                    }

                case 2:
                    {
                        do
                        {
                            //This uses a pre defined array to produce a Blinker
                            LC.BlinkerGeneration();
                            while (!Console.KeyAvailable)
                            {
                                Console.SetCursorPosition(0, Console.WindowTop);
                                generation++;
                                LC.GameStart();
                                Console.WriteLine("Generation = " + generation);
                                Console.WriteLine("Press ESC to stop");
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                        break;
                    }
                case 3:
                    {
                        do
                        {
                            //This uses a pre defined array to produce a Glider
                            LC.GliderGeneration();
                            while (!Console.KeyAvailable)
                            {
                                Console.SetCursorPosition(0, Console.WindowTop);
                                generation++;
                                LC.GameStart();
                                Console.WriteLine("Generation = " + generation);
                                Console.WriteLine("Press ESC to stop");
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                        break;
                    }
            }            
        }
    }
}

