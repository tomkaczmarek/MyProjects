using System.Collections.Generic;
using System.Windows;
using GitHubCollector.Service;
using GitHubCollector.Util;
using GitHubCollector.Collectors;
using GitHubCollector.Factory;
using System.Configuration;
using System;
using System.Reflection;

namespace GitHubCollectorView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ICommitsCollector commits = CollectorFactory.CreateCommitsCollector(userName.Text, repositoryName.Text, new GitHubServiceProvider());
            IList<Commit> commitsList = commits.GetCommitsList();
            if (commitsList != null)
            {
                IList<Commit> filterCommitList = commits.GetFilteredCommitsList(commitsList);
                IList<Commit> averageCommitList = commits.GetAverageCommitsList(filterCommitList);
                lvAllCommits.ItemsSource = commitsList;
                lvFilterCommits.ItemsSource = filterCommitList;
                lvAverageCommits.ItemsSource = averageCommitList;
            }
            else
                MessageBox.Show("Page is not exist!");          
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            IList<string> service = new List<string>();
            service.Add("GitHubServiceProvider");

            this.ddServisList.ItemsSource = ConfigurationManager.AppSettings;
            this.ddServisList.SelectedIndex = 0;
        }
    }
}
