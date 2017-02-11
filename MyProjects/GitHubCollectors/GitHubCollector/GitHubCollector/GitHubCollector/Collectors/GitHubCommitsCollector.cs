using System;
using System.Collections.Generic;
using System.Linq;
using Git = GitHubCollector.Util;
using LibGit2Sharp;
using System.IO;
using GitHubCollector.Service;
using System.Net;

namespace GitHubCollector.Collectors
{
    public class GitHubCommitsCollector : AbstractCommitCollector
    {
        private string _user;
        private string _repository;
        private IRepoServiceProvider _service;
        private IList<Git.Commit> _commitList;

        /// <summary>
        /// Create new commits collector object
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="repository">repository name</param>
        /// <param name="service">service</param>
        public GitHubCommitsCollector(string user, string repository, IRepoServiceProvider service)
        {
            this._user = user;
            this._repository = repository;
            this._service = service;
        }

        /// <summary>
        /// Get list of all commits on repository
        /// </summary>
        /// <returns>List of commits</returns>
        public override IList<Git.Commit> GetCommitsList()
        {
            try
            {
                string url = GetUrl(_user, _repository, _service);
                if(IsPageExists(url))
                {
                    _commitList = new List<Git.Commit>();
                    string path = Repository.Clone(url, CreateTempPath());

                    using (var repository = new Repository(path))
                    {
                        foreach (var branch in repository.Branches)
                        {
                            foreach (var commit in branch.Commits)
                            {
                                Git.Commit c = new Git.Commit()
                                {
                                    Committer = commit.Committer.Name,
                                    CommitDate = commit.Committer.When.DateTime,
                                    Message = commit.MessageShort,
                                    BranchName = branch.FriendlyName,
                                    CommitDateString = commit.Committer.When.DateTime.ToShortDateString()
                                };
                                _commitList.Add(c);
                            }
                        }
                    }

                    _commitList = _commitList.OrderByDescending(d => d.CommitDate).GroupBy(x => x.CommitDate).Select(y => y.First()).ToList();

                    //TODO 
                    //Delete directory
                    DeleteTempFiles(path);
                }
                
                return _commitList;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }          
        }

        /// <summary>
        /// Get filtered list of commits
        /// </summary>
        /// <param name="commitslist"></param>
        /// <returns></returns>
        public override IList<Git.Commit> GetFilteredCommitsList(IList<Git.Commit> commitslist)
        {
            var result = commitslist.GroupBy(c => new
            {
                c.CommitDateString,
                c.Committer
            })
            .Select(g => new Git.Commit
            {
                CommitDateString = g.Key.CommitDateString,
                Committer = g.Key.Committer,
                CommitsCount = g.Count(),                
            })
            .ToList();

            return result;
        }

        public override IList<Git.Commit> GetAverageCommitsList(IList<Git.Commit> commitsList)
        {
            var result = commitsList.GroupBy(p => new
            {
                p.Committer,
            })
            .Select(g => new Git.Commit
            {
                Committer = g.Key.Committer,
                AverageCommiPerDay = g.Sum(p => p.CommitsCount) / g.Count()
            })
            .ToList();

            return result;
        }

        /// <summary>
        /// Get full path of repository service
        /// </summary>
        /// <param name="user"></param>
        /// <param name="repository"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public override string GetUrl(string user, string repository, IRepoServiceProvider service)
        {
            return string.Format("{0}/{1}/{2}", service.GetServiceUrl(), user, repository);
        }

        private bool IsPageExists(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Head;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK;
        }

        private string CreateTempPath()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        }

        private void DeleteTempFiles(string path)
        {            
            var dir = Directory.GetParent(path);
            if (dir.Parent.Exists)
                dir.Parent.EnumerateFiles().ToList().ForEach(f => f.Delete());                       
        }
        
    }
}
