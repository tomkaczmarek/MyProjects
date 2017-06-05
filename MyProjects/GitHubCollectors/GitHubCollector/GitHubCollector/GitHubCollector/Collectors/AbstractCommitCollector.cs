using System;
using System.Collections.Generic;
using GitHubCollector.Model;
using GitHubCollector.Service;
using GitHubCollector.Util;

namespace GitHubCollector.Collectors
{
    public abstract class AbstractCommitCollector : ICommitsCollector
    {
        
        public abstract IList<Commit> GetCommitsList();

        public abstract IList<Commit> GetFilteredCommitsList(IList<Commit> commitslist);

        public abstract IList<Commit> GetAverageCommitsList(IList<Commit> commitsList);

        public virtual string GetUrl(string user, string repository, IRepoServiceProvider service)
        {
            throw new NotImplementedException();
        }

        public virtual IList<RepositoryModel> GetRepositorys(string repositorys, IRepoServiceProvider service)
        {
            throw new NotImplementedException();
        }
    }
}
