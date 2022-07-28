namespace MovieDatabase
{
    internal class MainMenu
    {
        public static void StartMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Troy's Movie List Application!");
            Console.WriteLine();
            ListOfMovies.PrintCategories();
            Console.WriteLine();
            Console.WriteLine("Enter a movie Category you would like to see.");
            Console.WriteLine("Or you can select a Category by index numbers.");
            Console.WriteLine("Enter administrator PASSWORD to add or remove movies from the list.");
            Console.WriteLine($"There are {ListOfMovies.movieList.Count} movies in this list.");
            Console.WriteLine();

            string input = Console.ReadLine().ToLower().Trim();
            string[] choice = ListOfMovies.categories.Where(c => c.ToLower().Trim().StartsWith(input)).ToArray();

            if(input == "password")
            {
                Administrator.AdministratorAccess();
                return;
            }
            else if(choice.Length == 1)
            {
                ListOfMovies.PrintMovieCategory(choice[0]);
                return;
            }
            else if(int.TryParse(input, out int index) && --index < ListOfMovies.categories.Count)
            {
                ListOfMovies.PrintMovieCategory(ListOfMovies.categories.ElementAt(index));
                return;
            }
            else if(choice.Length > 1 && input != String.Empty)
            {
                Console.Clear();
                Console.WriteLine("More then one category matched your search.");
                return;
            }
            Console.Clear();
            Console.WriteLine("No categorys matched your search input.");
        }
    }
}