
namespace MovieDatabase
{
    internal class ListOfMovies
    {
        public static void MakeListOfMovies()
        {
            List<Movie> list = new List<Movie>();

            list.Add(new Movie( "bob", "category1"));
            list.Add(new Movie( "tom", "category2"));



            list.Where(s => s.GetCategory == "category1")
                .ToList()
                .ForEach(w => Console.WriteLine(w.GetTitle));



            //Console.WriteLine(list.);
            //foreach(var item in list)
            //{
            //    Console.Write(item.GetId + " ");
            //    Console.Write(item.GetTitle + " ");
            //    Console.WriteLine(item.GetCategory);
            //}
        }
    }
}
