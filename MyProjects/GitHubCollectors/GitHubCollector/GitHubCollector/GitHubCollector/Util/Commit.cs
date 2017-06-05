using System;

namespace GitHubCollector.Util
{
    public class Commit
    {

        private string _committer, _message, _branch, _fileName, _commitDateString;
        private DateTime _commitDate;
        private int _count;
        private double _averageCommitPerDay;

        public string Committer
        {
            get { return _committer; }
            set { _committer = value; }
        }
        public DateTime CommitDate
        {
            get { return _commitDate; }
            set { _commitDate = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string BranchName
        {
            get { return _branch; }
            set { _branch = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public int CommitsCount
        {
            get { return _count; }
            set { _count = value; }
        }

        //TODO I don,t like this
        public string CommitDateString
        {
            get { return _commitDateString; }
            set { _commitDateString = value; }
        }

        public double AverageCommiPerDay
        {
            get { return _averageCommitPerDay; }
            set { _averageCommitPerDay = value; }
        }

        public string Email { get; set; }

        public Commit() { }

    }
}
