﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.IO;

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
            var basicAuth = new Credentials(username, password); 
            client.Credentials = basicAuth;
            string filePath = "..\\..\\..\\data.csv"; 
            File.Create(filePath);

            //The below code displays info regarding a developer of your choosing
            /*var user = await client.User.Get("YasirZardari");
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

            Console.WriteLine("number of repos: " + count);
            for (int i = 0; i < count; i++)
            {
             var repoLanguage = repos.ElementAt(i).Language;
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


            string text = "language,count\n";
            File.AppendAllText(filePath, text);
            text = "Java," + JavaCount + "\n";
            File.AppendAllText(filePath, text);
            text = "Python," + PythonCount + "\n";
            File.AppendAllText(filePath, text);
            text = "C#," + CSharpCount + "\n";
            File.AppendAllText(filePath, text);
            text = "C++," + CplusCount + "\n";
            File.AppendAllText(filePath, text);
            text = "Objective-C," + ObjC_Count + "\n";
            File.AppendAllText(filePath, text);
            text = "JavaScript," + JavascriptCount + "\n";
            File.AppendAllText(filePath, text);
            text = "Ruby," + RubyCount + "\n";
            File.AppendAllText(filePath, text);
            text = "PHP," + PHPCount + "\n";
            File.AppendAllText(filePath, text);
            text = "C," + C_Count + "\n";
            File.AppendAllText(filePath, text);
            text = "Other," + OtherCount + "\n";
            File.AppendAllText(filePath, text);

            //File.Create(filePath).Close();
            Console.ReadLine();
        }
    }
}

