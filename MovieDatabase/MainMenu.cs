using static MovieDatabase.ListOfMovies;

namespace MovieDatabase
{
    internal class MainMenu
    {
        public static void StartMainMenu()
        {
            PrintCategories();

            Console.WriteLine();
            Console.WriteLine("Enter a movie category you would like to see.");
            Console.WriteLine("Or you can select a category by index numbers.");
            Console.WriteLine($"There are {movieList.Count} movies in this list.");
            Console.WriteLine();
            string input = Console.ReadLine().ToLower().Trim();
            if(input != string.Empty && categories.Where(c => c.ToLower().Trim().StartsWith(input)).Any())
            {
                string[] choice = categories.Where(c => c.ToLower().Trim().StartsWith(input)).ToArray();
                if(choice.Length == 1)
                {
                    foreach(var cat in categories)
                    {
                        if(choice[0] == cat)
                        {
                            PrintMovieCategory(cat);
                            //break;
                        }
                    }
                }
            }
            else if(int.TryParse(input, out int index) && --index < categories.Count)
            {
                PrintMovieCategory(categories.ElementAt(index));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
