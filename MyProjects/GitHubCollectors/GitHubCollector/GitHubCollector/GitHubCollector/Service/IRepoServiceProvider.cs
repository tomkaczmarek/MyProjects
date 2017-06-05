using System;

namespace GitHubCollector.Service
{
    public interface IRepoServiceProvider
    {
        string GetServiceUrl();

        string GetApiUrl(string user);
    }
}
