using System.Collections.Generic;
using GitHubCollector.Util;
using GitHubCollector.Service;
using GitHubCollector.Model;

namespace GitHubCollector.Collectors
{
    public interface ICommitsCollector 
    {
        IList<Commit> GetCommitsList();
        IList<Commit> GetFilteredCommitsList(IList<Commit> commitslist);
        IList<Commit> GetAverageCommitsList(IList<Commit> commitsList);
        string GetUrl(string user, string repository, IRepoServiceProvider service);
        IList<RepositoryModel> GetRepositorys(string repositorys, IRepoServiceProvider service);
    }
}
