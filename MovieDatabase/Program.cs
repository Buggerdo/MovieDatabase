using static MovieDatabase.ListOfMovies;
using static MovieDatabase.MainMenu;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            MakeMovieList();
            MakeCategories();

            do
            {
                StartMainMenu();
            } while(Exit());
        }


        /// <summary>
        /// Checks to see if user wants to continue
        /// </summary>
        /// <returns>returns true if user wants to continue</returns>
        private static bool Exit()
        {
            string[] no = { "no", "exit", "quit" };

            Console.WriteLine();
            Console.Write("Press any key to continue or exit to quit: ");
            string contiue = Console.ReadLine().ToLower().Trim();
            if(contiue != String.Empty && no.Where(n => n.StartsWith(contiue)).Any())
            {
                Console.Clear();
                return false;
            }
            Console.Clear();
            return true;
        }
    }
}