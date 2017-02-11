using GitHubCollector.Service;
using GitHubCollector.Collectors;

namespace GitHubCollector.Factory
{
    public class CollectorFactory
    {
        static public ICommitsCollector CreateCommitsCollector(string user, string repository, IRepoServiceProvider service)
        {
            ICommitsCollector collector = null;
            if (service is GitHubServiceProvider)
                collector = new GitHubCommitsCollector(user, repository, service);
            return collector;
        }
    }
}
