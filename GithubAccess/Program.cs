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
            Console.Write("Please enter user you want to retrieve data for: ");
            String GithubUser = Console.ReadLine();
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
            var repos = await client.Repository.GetAllForUser(GithubUser);
            var count = repos.Count;

            var JavaCount = 0;
            var C_Count = 0;
            var PythonCount = 0;
            var JavascriptCount = 0;
            var PHPCount = 0;
            var CSharpCount = 0;
            var RubyCount = 0;
            var ObjC_Count = 0;
            var CplusCount = 0;
            var OtherCount = 0;
            //var lang = repos.ElementAt(0).Language;
            Console.WriteLine("number of repos: " + count);
            for (int i = 0; i < count; i++)
            {
            //Console.WriteLine(repos.ElementAt(i).Name + " - " + repos.ElementAt(i).Language);
             //var repoName = repos.ElementAt(i).Name;
             var repoLanguage = repos.ElementAt(i).Language;
             //Console.WriteLine(repos.ElementAt(i).Name + " - " + repos.ElementAt(i).Language);
             if (String.Compare("Java",repoLanguage) == 0)
             {
                    JavaCount++;
             }
             else if (String.Compare("C", repoLanguage) == 0)
             {
                    C_Count++;
             }
             else if (String.Compare("C#", repoLanguage) == 0)
             {
                    CSharpCount++;
             }
             else if (String.Compare("PHP", repoLanguage) == 0)
             {
                    PHPCount++;
             }
             else if (String.Compare("Objective-C", repoLanguage) == 0)
             {
                    ObjC_Count++;
             }
             else if (String.Compare("JavaScript", repoLanguage) == 0)
             {
                    JavascriptCount++;
             }
             else if (String.Compare("Python", repoLanguage) == 0)
             {
                    PythonCount++;
             }
             else if (String.Compare("C++", repoLanguage) == 0)
             {
                    CplusCount++;
             }
             else if (String.Compare("Ruby", repoLanguage) == 0)
             {
                    RubyCount++;
             }
                else
             {
                    OtherCount++;
             }


            }
            Console.WriteLine("Java - " + JavaCount);
            Console.WriteLine("Python - " + PythonCount);
            Console.WriteLine("C# - " + CSharpCount);
            Console.WriteLine("C++ - " + CplusCount);
            Console.WriteLine("ObjC - " + ObjC_Count);
            Console.WriteLine("JavaScript - " + JavascriptCount);
            Console.WriteLine("Ruby - " + RubyCount);
            Console.WriteLine("PHP - " + PHPCount);
            Console.WriteLine("C - " + C_Count);
            Console.WriteLine("Other - " + OtherCount);


            Console.ReadLine();
        }
    }
}

