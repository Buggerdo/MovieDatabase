namespace MovieDatabase
{
    internal class MainMenu
    {
        public static void StartMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Movie List Application!");
            Console.WriteLine();
            ListOfMovies.PrintCategories();
            Console.WriteLine();
            Console.WriteLine("Enter a movie Category you would like to see.");
            Console.WriteLine("Or you can select a Category by index numbers.");
            Console.WriteLine("Enter administrator PASSWORD to add or remove movies from the list.");
            Console.WriteLine($"There are {ListOfMovies.movieList.Count} movies in this list.");
            Console.WriteLine();
            string input = Console.ReadLine().ToLower().Trim();

            if(input == "password")
            {
                Administrator.AdministratorAccess();
            }
            else if(input != string.Empty && ListOfMovies.categories.Where(c => c.ToLower().Trim().StartsWith(input)).Any())
            {
                string[] choice = ListOfMovies.categories.Where(c => c.ToLower().Trim().StartsWith(input)).ToArray();
                if(choice.Length == 1)
                {
                    foreach(var cat in ListOfMovies.categories)
                    {
                        if(choice[0] == cat)
                        {
                            ListOfMovies.PrintMovieCategory(cat);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, there was more then one entry that matched your search.");
                }
            }
            else if(int.TryParse(input, out int index) && --index < ListOfMovies.categories.Count)
            {
                ListOfMovies.PrintMovieCategory(ListOfMovies.categories.ElementAt(index));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
