using System.Text.RegularExpressions;

namespace Crawler1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentNullException();
            }

            string url = args[0];

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                throw new ArgumentException("Podany argument nie jest poprawnym adresem URL");
            }

            using HttpClient client = new();
            
            HttpResponseMessage result = await client.GetAsync(url);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Błąd w czasie pobierania strony");
            }

            string content = await result.Content.ReadAsStringAsync();
         
            HashSet<string> emailSet = FindEmails(content);

            if (emailSet.Count == 0)
            {
                throw new Exception("Nie znaleziono adresow email");
            }

            foreach (string email in emailSet)
            {
                Console.WriteLine(email);
            }
        }

        static HashSet<string> FindEmails(string html)
        {
            Regex emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
            MatchCollection matches = emailRegex.Matches(html);
            HashSet<string> emails = new HashSet<string>();


            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }
            return emails;
        }
    }
}