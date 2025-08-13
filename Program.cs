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
        //opsæt af hoved menuen for biografen
        static void Biomenu()
        {
            while (true)  // Loop forever until break
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║   Velkommen til Ballerup bio   ║");
                Console.WriteLine("╠════════════════════════════════╣");

                for (int i = 0; i < film.Length; i++)
                {
                    Console.WriteLine($"║ {i + 1}. {film[i],-28}║");
                }

                Console.WriteLine("╚════════════════════════════════╝");
                Console.WriteLine();

                Console.Write("Vælg en film ved at indtaste nummeret: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int valg))
                {
                    if (valg >= 1 && valg <= film.Length)
                    {
                        FilmMenu(valg - 1); // Gå videre til filmens menu
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt nummer. Prøv igen.");
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldigt input. Prøv igen.");
                    Thread.Sleep(1500);
                }
            }

        }
        private static void VisSal(int salValg)
        {
            Console.Clear();
            Console.WriteLine("                         Lærred her");
            Console.WriteLine("-----------------------------------------------------------");
            for (int række = 0; række < AntalRækker; række++)
            {
                for (int sæde = 0; sæde < AntalSæder; sæde++)
                {
                    if (biograf[salValg, sæde, række])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ■ ");

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Række {række + 1,2}");
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int sæde = 1; sæde <= AntalSæder; sæde++)
            {
                string sædenummerformat = string.Format("{0,2} ", sæde);
                Console.Write(sædenummerformat);
            }
            Console.WriteLine();
           
        }
        // Undermenu for en valgt film
        static void FilmMenu(int valgtfilm)
        {
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine($"Du har valgt: {film[valgtfilm]}");
                Console.WriteLine("1. Book plads");
                Console.WriteLine("2. Se pladser i salen");
                Console.WriteLine("3. Tilbage til hovedmenuen");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        BookPlads(valgtfilm);
                        break;
                    case "2":
                        VisSal(valgtfilm);
                        Console.WriteLine("Tryk på en tast for at fortsætte ");
                        Console.ReadKey();
                        break;
                    case "3":
                        finish = true; // Set finish to true to exit the loop
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
        static void BookPlads(int sal)
        {
            while (true)
            {
                DisplaySal(sal);
                Console.WriteLine();

                Console.Write("Vælg række (1-12): ");
                int række = ValiderInput(1, AntalRækker);

                Console.Write("Vælg sæde (1-20): ");
                int sæde = ValiderInput(1, AntalSæder);

                // Tjek om pladsen allerede er booket
                if (biograf[sal, sæde - 1, række - 1])
                {
                    Console.WriteLine("Pladsen er allerede booket. Prøv en anden.");
                    Thread.Sleep(2000);
                }
                else
                {
                    biograf[sal, sæde - 1, række - 1] = true;
                    Console.WriteLine($"Plads {sæde}, række {række} er nu booket!");
                    Thread.Sleep(2000);
                    break;
                }
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
        static void DisplaySal(int sal)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      Salsoversigt                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");

            for (int række = 0; række < AntalRækker; række++)
            {
                // Print row number with padding
             
                Console.ForegroundColor = ConsoleColor.Green;
                
                for (int sæde = 0; sæde < AntalSæder; sæde++)
                    {
                    if (biograf[sal, sæde, række])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        
                    }
                    Console.Write("■ ");

                }
                Console.WriteLine($"Række {række + 1,2}");
                
            }
            Console.ResetColor(); // Reset color to default
            Console.WriteLine("\nGrøn = ledig  Rød = Optaget");
        }
    }
}
