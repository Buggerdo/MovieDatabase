using static MovieDatabase.ListOfMovies;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            bool more = true;
            string[] no = { "no", "exit", "quit" };
            categories.Sort();

            Console.WriteLine("Welcome to the Movie List Application!");

            do
            {
                Console.WriteLine("\nEnter a movie category to see a list of movies or \"List\" to see a list of movie categories.");
                Console.WriteLine($"There are {movieList.Count} movies in this list.");
                string input = Console.ReadLine();
                if("list".StartsWith(input) && input != "")
                {
                    PrintCategories();
                    continue;
                }
                else if(categories.Where(c => c.ToLower().StartsWith(input)).Any() && input != "")
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
                }

                Console.Write("\nPress any key to continue or exit to quit: ");
                string contiue = Console.ReadLine().ToLower().Trim();
                if(no.Where(n => n.StartsWith(contiue)).Any() && contiue != "")
                {
                    more = false;
                }
                Console.Clear();
            } while(more);
        }
    }
}