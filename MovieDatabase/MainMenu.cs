using static MovieDatabase.ListOfMovies;

namespace MovieDatabase
{
    internal class MainMenu
    {
        public static bool StartMainMenu()
        {
            do
            {
                Console.WriteLine("\nEnter a movie category to see a list of movies or \"List\" to see a list of movie categories.");
                Console.WriteLine($"There are {movieList.Count} movies in this list.");
                string input = Console.ReadLine().ToLower().Trim();
                if(input != string.Empty && "list".StartsWith(input))
                {
                    PrintCategories();
                    continue;
                }
                if(input != String.Empty && categories.Where(c => c.ToLower().StartsWith(input)).Any())
                {
                    string[] choice = categories.Where(c => c.ToLower().StartsWith(input)).ToArray();
                    if(choice.Length == 1)
                    {
                        foreach(var cat in categories)
                        {
                            if(choice[0] == cat)
                            {
                                PrintMovieCategory(cat);
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
                    Console.WriteLine("Invalid input.");
                    return true;
                }

                return false; 
            } while(true);
        }
    }
}
