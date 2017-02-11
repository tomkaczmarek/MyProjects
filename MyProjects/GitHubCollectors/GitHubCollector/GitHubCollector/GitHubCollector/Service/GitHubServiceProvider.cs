using System;

namespace GitHubCollector.Service
{
    public class GitHubServiceProvider : RepoServiceProvider
    {
        public override string GetServiceUrl()
        {
            return "https://github.com";
        }
    }
}
