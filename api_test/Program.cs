using System;
using System.Threading.Tasks;
using Octokit;


class Program
{ 
       public async static Task Main()
        {
        var client = new GitHubClient(new ProductHeaderValue("test-app"));
        var user = await client.User.Get("medic17");

        Console.WriteLine("{0} has {1} public repositories. Url is {2}",
            user.Login,
            user.PublicRepos,
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
        }
}