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
          //  Console.Write("Please enter user you want to retrieve data for: ");
            //String GithubUser = Console.ReadLine();
            var basicAuth = new Credentials(username, password); // NOTE: not real credentials
            client.Credentials = basicAuth;

            var user = await client.User.Get("YasirZardari");
            /*           Console.WriteLine("{0} has {1} public repositories - go check out their profile at {2}",
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
                   */
            var repos = await client.Repository.GetAllForCurrent();
            var count = repos.Count;

            var JavaCount = 0;
            var C_Count = 0;
            var PythonCount = 0;
            var JavascriptCount = 0;
            var HtmlCount = 0;
            var CSharpCount = 0;
            var RubyCount = 0;
            var ObjC_Count = 0;
            var CplusCount = 0;
            //var lang = repos.ElementAt(0).Language;
            Console.WriteLine("number of repos: " + count);
            for (int i = 0; i < count; i++)
            {
            //Console.WriteLine(repos.ElementAt(i).Name + " - " + repos.ElementAt(i).Language);
             //var repoName = repos.ElementAt(i).Name;
             var repoLanguage = repos.ElementAt(i).Language;
             Console.WriteLine(repos.ElementAt(i).Name + " - " + repos.ElementAt(i).Language);
             if (String.Compare("Java",repoLanguage) == 0)
             {
                    JavaCount++;
             }
             
           
            }
            Console.WriteLine(JavaCount);

           
            Console.ReadLine();
        }
    }
}

