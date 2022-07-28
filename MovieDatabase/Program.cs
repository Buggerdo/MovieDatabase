namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            ListOfMovies.MakeMovieList();
            ListOfMovies.MakeCategories();

            do
            {
                MainMenu.StartMainMenu();
            } while(Validator.Exit());
        }
    }
}