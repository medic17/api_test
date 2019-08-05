using System;
using System.Threading.Tasks;
using api_test;
using Octokit;



class Program
{ 
       public async static Task Main()
        {
        var client = new GitHubClient(new ProductHeaderValue("test-app"));
        var user = await client.User.Get("medic17");
        var tokenAuth = new Credentials(APIKeys.GithubPersinalAccessToken);
        client.Credentials = tokenAuth;

        Console.WriteLine("{0} has {1} public repositories and {2} visible private repositories. Url is {3}",
            user.Login,
            user.PublicRepos,
            user.OwnedPrivateRepos,
            user.Url
            );
        Console.ReadLine();

        var miscelaneousRateLimit = await client.Miscellaneous.GetRateLimits();

        var coreRateLimit = miscelaneousRateLimit.Resources.Core;

        var CoreRequestsPerHour = coreRateLimit.Limit;
        var CoreRequestsLeft = coreRateLimit.Remaining;
        var coreLimitResetTime = coreRateLimit.Reset;

        Console.WriteLine("Your requests per hour are {0}. You have {1} reqests left. The reset is at {2}", 
            CoreRequestsPerHour,
            CoreRequestsLeft,
            coreLimitResetTime
            );
        Console.ReadLine();

        // Issues
        var issues = await client.Issue.GetAllForCurrent();
        var issueCount = issues.Count;
        
        Console.WriteLine("You have {0} issues in all your repos", issueCount);
        Console.ReadLine();
        }
}