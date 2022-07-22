using static MovieDatabase.ListOfMovies;
using static MovieDatabase.MainMenu;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            bool more = true;

            MakeMovieList();
            GetCategories();


            Console.WriteLine("Welcome to the Movie List Application!");

            do
            {
                StartMainMenu();

                Console.WriteLine();
                Console.Write("Press any key to continue or exit to quit: ");
                string contiue = Console.ReadLine().ToLower().Trim();
                string[] no = { "no", "exit", "quit" };
                if(contiue != String.Empty && no.Where(n => n.StartsWith(contiue)).Any())
                {
                    more = false;
                }
                Console.Clear();

            } while(more);
        }
    }
}