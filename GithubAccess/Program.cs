using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GithubAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var client = new GitHubClient(new ProductHeaderValue("this-is-Yasir"));

            Console.Write("Please enter username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter password: ");
            string password = Console.ReadLine();
            var basicAuth = new Credentials(username, password); // NOTE: not real credentials
            client.Credentials = basicAuth;

            var user = await client.User.Get("YasirZardari");
            Console.WriteLine("{0} has {1} public repositories - go check out their profile at {2}",
                user.Name,
                user.PublicRepos,
                user.Url);
            Console.WriteLine(user.CreatedAt);

            var repos = await client.Repository.GetAllForCurrent();
            var count = repos.Count;
            Console.WriteLine($"Here are {user}'s repositories: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(repos.ElementAt(i).Name);
            }

            Console.ReadLine();
            //Test comment
        }
    }
}

