using System;

namespace GitHubCollector.Service
{
    public class RepoServiceProvider : IRepoServiceProvider
    {
        virtual public string GetApiUrl(string user)
        {
            throw new NotImplementedException();
        }

        virtual public string GetServiceUrl()
        {
            throw new NotImplementedException();
        }
    }
}
