namespace bio_opg
{
    internal class Program
    {
        const int AntalSale = 4;
        const int AntalSæder = 20;
        const int AntalRækker = 12;
        // Declare film array here so it's accessible everywhere in the class
        static string[] film = { "F1 filmen", "Demonslayer Mugen Train", "Avatar 2", "Oppenheimer" };
        static bool[,,] biograf = new bool[AntalSale, AntalSæder, AntalRækker];
        static void Main(string[] args)
        {
            // Initialize the cinema with some booked seats for demonstration
            biograf[0, 7, 6] = true;
            biograf[0, 10, 6] = true;
            biograf[0, 11, 6] = true;
            biograf[0, 19, 6] = true;
            // Call the menu function to start the program
            Biomenu();
            Console.ReadKey();
        }

        static void Biomenu()
        {
            while (true)  // Loop forever until break
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║  Velkommen til Ballerup bio  ║");
                Console.WriteLine("╠══════════════════════════════╣");

                for (int i = 0; i < film.Length; i++)
                {
                    Console.WriteLine($"║ {i + 1}. {film[i],-28}║");
                }

                Console.WriteLine("╚══════════════════════════════╝");
                Console.WriteLine();

                Console.Write("Vælg en film ved at indtaste nummeret: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= film.Length)
                    {
                        Console.WriteLine($"Du har valgt: {film[choice - 1]}");
                        Thread.Sleep(2000);
                        VisSal(choice - 1);

                        break;  // Exit the loop once a valid choice is made
                    }
                }

                // If we get here, input was invalid
                Console.WriteLine("Ugyldigt valg, prøv igen.");
                Console.WriteLine();
            }

        }
        private static void VisSal(int salValg)
        {
            Console.Clear();
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
        static void BookPlads(int sal)
        {
            while (true)
            {
                Console.Clear();
                VisSal(sal); //viser pladser i salen
                Console.ResetColor(); // Reset color til default

                Console.WriteLine("\nIndtast række (1-12): ");
                int række = ValiderInput(1, AntalRækker); // -1 for 0-based index
            }
        }
        static int ValiderInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int tal))
                {
                    if (tal >= min && tal <= max)
                        return tal;
                }
                Console.WriteLine($"Ugyldigt input. Indtast et tal mellem {min} og {max}: ");
            }
        }
    }
}
