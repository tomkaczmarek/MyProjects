using System;

namespace GitHubCollector.Service
{
    public class RepoServiceProvider : IRepoServiceProvider
    {
        virtual public string GetServiceUrl()
        {
            throw new NotImplementedException();
        }
    }
}
