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
            LifeChoices LC = new LifeChoices();

            //Ask for type of game          
            int gametype = LC.InitialiseGame();

            switch (gametype)
            {
                case 1:
                    {
                        do
                        {
                            int generation = 0;
                            LC.RandomGeneration();
                            while (!Console.KeyAvailable)
                            {
                                Console.SetCursorPosition(0, Console.WindowTop);
                                System.Threading.Thread.Sleep(800);
                                generation++;
                                LC.WriteLife();
                                LC.NextGeneration();
                                LC.UpdateLife();
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
                            int generation = 0;
                            LC.PreGeneration();
                            while (!Console.KeyAvailable)
                            {
                                Console.SetCursorPosition(0, Console.WindowTop);
                                System.Threading.Thread.Sleep(800);
                                generation++;
                                LC.WriteLife();
                                LC.NextGeneration();
                                LC.UpdateLife();
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

