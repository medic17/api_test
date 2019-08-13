using System;
using System.Threading.Tasks;
using api_test;
using Octokit;


/********* example code *****************************************
    Finished: adding issue via hardcod    
    TODO: add issue via user input in console
*****************************************************************/

class Program
{ 
       public async static Task Main()
        {
        var client = new GitHubClient(new ProductHeaderValue("test-app"));
        var user = await client.User.Get("medic17");
        var tokenAuth = new Credentials(APIKeys.GithubPersinalAccessToken);
        client.Credentials = tokenAuth;

        /*
        // user input
        Console.WriteLine("What is your issue?", Environment.NewLine);
        string userIssue = Console.ReadLine();

        // input validation
        while (string.IsNullOrEmpty(userIssue))
        {
            Console.WriteLine("empty response");
            userIssue = Console.ReadLine();
        }

        Console.WriteLine($"your issue text is: {userIssue}");
        Console.ReadLine();
        */

        string title = "A test issue";
        string description = "body text";

        var newIssue = new NewIssue(title) { Body = description };
        var issue = await client.Issue.Create(200635224, newIssue);
        }
}