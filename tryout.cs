using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace bio_opg
{
   internal class trial
    {
       /* const int AntalSale = 4;
        const int AntalSæder = 20;
        const int AntalRækker = 12;
        static string[] Film = { "Demon Slayer: Infinity Castle, Del 1", "Lilo & Stitch", "Harry Potter", "Weapons" };
        static bool[,,] biograf = new bool[AntalSale, AntalSæder, AntalRækker];
        /// <summary>
        /// Biograf opgave det grafiske
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            biograf[0, 9, 6] = true;
            biograf[0, 10, 6] = true;
            biograf[0, 11, 6] = true;
            biograf[0, 12, 6] = true;
            int filmIndex = 1;
            foreach (var f in Film)
            {2
                Console.WriteLine($"{filmIndex}. {f}");
                filmIndex++;
            }
            Console.WriteLine("Indtast hvilken film du vil se");
            if (int.TryParse(Console.ReadLine(), out int SalValg))
            {
                DisplaySal(SalValg - 1);
            }
            Console.ReadKey();
        }

        private static void DisplaySal(int salValg)
        {

            for (int i = 0; i < AntalRækker; i++)
            {
                for (int y = 0; y < AntalSæder; y++)
                {
                    if (biograf[salValg, y, i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ■");
                }
                Console.WriteLine();
            }
       
        }
    }
}*/