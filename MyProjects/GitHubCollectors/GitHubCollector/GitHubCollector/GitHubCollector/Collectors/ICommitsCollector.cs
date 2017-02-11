using System.Collections.Generic;
using GitHubCollector.Util;
using GitHubCollector.Service;

namespace GitHubCollector.Collectors
{
    public interface ICommitsCollector 
    {
        IList<Commit> GetCommitsList();
        IList<Commit> GetFilteredCommitsList(IList<Commit> commitslist);
        IList<Commit> GetAverageCommitsList(IList<Commit> commitsList);
        string GetUrl(string user, string repository, IRepoServiceProvider service);
    }
}
