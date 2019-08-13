using System;
using System.Threading.Tasks;
using api_test;
using Octokit;


/********************Progress************************************
    Finished: add issue via user input in console    
    TODO: connect logic to mvvm wpf
*****************************************************************/

class Program
{
    public async static Task Main()
    {
        var client = new GitHubClient(new ProductHeaderValue("test-app"));
        var user = await client.User.Get("medic17");
        var tokenAuth = new Credentials(APIKeys.GithubPersinalAccessToken);
        client.Credentials = tokenAuth;


        // user input
        Console.WriteLine("Give a title for your issue: ");
        string userIssueTitle = Console.ReadLine().Trim();

        Console.WriteLine("Describe your issue:", Environment.NewLine);
        string userIssue = Console.ReadLine().Trim();

        // input validation
        while (string.IsNullOrEmpty(userIssue) || string.IsNullOrEmpty(userIssueTitle))
        {
            Console.WriteLine("ERROR: Both fields must contain text");
            Console.ReadLine();
            break;

        }

        var newIssue = new NewIssue(userIssueTitle) { Body = userIssue };
        var issue = await client.Issue.Create(200635224, newIssue);

        var issueId = issue.Id;

        Console.WriteLine($"SUCCESS: your issue id is {issueId} ");
        Console.ReadLine();
        
    
    }
}