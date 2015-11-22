namespace ConsumingWebServices
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            string queryString = "ge0rge314";

            var results = GoogleApi.GetResults(queryString);

            foreach (var result in results)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Title: {0},", result.Title);
                Console.WriteLine("Url: {0},", result.Url);
            }
        }
    }
}
