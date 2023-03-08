namespace Crawler1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException();
            }

            string url = args[0];

            using HttpClient client = new();
            //zawlnianie zasobow: client.Dispose();
            //ale zamiast można użyć scopa:
            //using(HttpClient client = new()){}
            //lub tak using HttpClient client = new();
            HttpResponseMessage result = await client.GetAsync(url);
            string content = await result.Content.ReadAsStringAsync();
        }
    }
}