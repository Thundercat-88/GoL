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
            do
            {
                int generation = 0;
                LC.FirstGeneration();
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("Press ESC to stop");
                    System.Threading.Thread.Sleep(250);
                    Console.WriteLine("Generation = " + generation);
                    generation++;
                    LC.WriteLife();
                    LC.NextGeneration();
                    LC.UpdateLife();
                }              
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ReadLine();
        }
    }
}

