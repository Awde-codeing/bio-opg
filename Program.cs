namespace bio_opg
{
    internal class Program
    {
        // Declare film array here so it's accessible everywhere in the class
        static string[] film = { "F1 filmen", "Demonslayer Mugen Train", "Avatar 2", "Oppenheimer" };

        static void Main()
        {
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
                        break;  // Exit the loop once a valid choice is made
                    }
                }

                // If we get here, input was invalid
                Console.WriteLine("Ugyldigt valg, prøv igen.");
                Console.WriteLine();
            }
        }
    }
}
