using System;

namespace GitHubCollector.Service
{
    public class GitHubServiceProvider : RepoServiceProvider
    {
        public override string GetServiceUrl()
        {
            return "https://github.com";
        }

        public override string GetApiUrl(string user)
        {
            return string.Format("{0}{1}{2}","http://api.github.com/users/", user, "/repos");
        }
    }
}
