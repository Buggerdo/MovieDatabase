using static MovieDatabase.ListOfMovies;
using static MovieDatabase.MainMenu;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            bool more = true;
            categories.Sort();

            Console.WriteLine("Welcome to the Movie List Application!");

            do
            {
                if(StartMainMenu()) 
                {
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    continue; 
                }

                Console.Write("\nPress any key to continue or exit to quit: ");
                string contiue = Console.ReadLine().ToLower().Trim();
                string[] no = { "no", "exit", "quit" };
                if(no.Where(n => n.StartsWith(contiue)).Any() && contiue != "")
                {
                    more = false;
                }
                Console.Clear();
            } while(more);
        }
    }
}