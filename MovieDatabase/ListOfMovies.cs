namespace MovieDatabase
{
    internal class ListOfMovies
    {
        private static readonly string lineBreak = "====================";

        public static List<string> categories = new();

        public static List<Movie> movieList = new();

        /// <summary>
        /// prints a list of movies in a category
        /// </summary>
        /// <param name="cat">Takes in a movie category and prints all the movies int that category</param>
        public static void PrintMovieCategory(string cat)
        {
            Console.Clear();
            Console.WriteLine($"List of {cat} movies.\n");
            Console.WriteLine(lineBreak);
            movieList.OrderBy(x => x.Title)
                .Where(s => s.Category == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.Title));
            Console.WriteLine(lineBreak);
        }

        /// <summary>
        /// compiles a list of categorys from the list of movies
        /// </summary>
        public static void MakeCategories()
        {
            movieList.Select(x => x.Category).Distinct()
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

        private static readonly string path = @"..\..\..\MovieList.txt";
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
            movieList = movieList.OrderBy(x => x.Category).ThenBy(x => x.Title).ToList();
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
                output.Add($"{movie.Title},{movie.Category}");
            }
            File.WriteAllLines(path, output);
        }

        /// <summary>
        /// Prints the full movie list
        /// </summary>
        public static void PrintFullMovieList()
        {
            Console.Clear();
            int index = 1;
            foreach(var movie in movieList)
            {
                Console.WriteLine($"{index++}: {movie.Title} {movie.Category}");
            }
        }

        public static void AddMovie()
        {
            string title;
            string category;
            bool isGoodTitle = false;
            do
            {
                Console.Clear();
                Console.Write("Please enter the movie title: ");
                title = Console.ReadLine().Trim();
                if(title.Length == 0 || title.Contains(','))
                {
                    Console.WriteLine("Empty String or invalid input");
                    Console.ReadKey();
                }
                else if(title.Length == 1)
                {
                    title = char.ToUpper(title[0]).ToString();
                    isGoodTitle = true;
                }
                else
                {
                    title = char.ToUpper(title[0]) + title[1..];
                    isGoodTitle = true;
                }
            } while(!isGoodTitle);

            bool isGoodCategory = false;
            do
            {
                Console.Clear();
                Console.Write("Please enter the movie category: ");
                category = Console.ReadLine().Trim();
                if(category.Length == 0 || category.Contains(','))
                {
                    Console.WriteLine("Empty String or invalid input");
                    Console.ReadKey();
                }
                else if(category.Length == 1)
                {
                    category = char.ToUpper(category[0]).ToString();
                    isGoodCategory = true;
                }
                else
                {
                    category = char.ToUpper(category[0]) + category[1..];
                    isGoodCategory = true;
                }
            } while(!isGoodCategory);

            Movie newMovie = new(title, category);
            movieList.Add(newMovie);
            movieList = movieList.OrderBy(x => x.Category).ThenBy(x => x.Title).ToList();
            SaveMovieList();
            MakeCategories();
        }

        public static void RemoveMovie()
        {

        }
    }
}