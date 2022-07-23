namespace MovieDatabase
{
    internal class ListOfMovies
    {
        private static readonly string lineBreak = "====================";

        public static List<string> categories = new();

        public static List<Movie> movieList = new();

        /// <summary>
        /// prints a list of movies in a Category
        /// </summary>
        /// <param name="cat">Takes in a movie category and prints all the movies int that category</param>
        public static void PrintMovieCategory(string cat)
        {
            Console.Clear();
            Console.WriteLine($"List of {cat} movies.\n");
            Console.WriteLine(lineBreak);
            movieList.OrderBy(x => x.GetTitle)
                .Where(s => s.GetCategory == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.GetTitle));
            Console.WriteLine(lineBreak);
        }

        /// <summary>
        /// compiles a list of categorys from the list of movies
        /// </summary>
        public static void MakeCategories()
        {
            movieList.Select(x => x.GetCategory).Distinct()
               .ToList().ForEach(y => categories.Add(y));
            categories.Sort();
        }

        /// <summary>
        /// prints a list of movie categories
        /// </summary>
        public static void PrintCategories()
        {
            int categoryNumber = 1;

            Console.WriteLine($"List of movie categories");
            Console.WriteLine();
            Console.WriteLine(lineBreak);
            categories.ForEach(i => Console.WriteLine($"{categoryNumber++}: {i}"));
            Console.WriteLine(lineBreak);
        }

        private static string path = @"..\..\..\MovieList.txt";
        /// <summary>
        /// Compiles a list of movies from text file
        /// </summary>
        public static void MakeMovieList()
        {
            string[] lines = File.ReadAllLines(path);

            foreach(string line in lines)
            {
                string[] entries = line.Split(',');
                Movie newMovie = new(entries[0], entries[1]);
                movieList.Add(newMovie);
            }
            movieList = movieList.OrderBy(x => x.GetCategory).ThenBy(x => x.GetTitle).ToList();
            SaveMovieList();
        }

        /// <summary>
        /// Saves the movie list back to file
        /// </summary>
        public static void SaveMovieList()
        {
            List<string> output = new();

            foreach(var movie in movieList)
            {
                output.Add($"{movie.GetTitle},{movie.GetCategory}");
            }
            File.WriteAllLines(path, output);
        }
    }
}