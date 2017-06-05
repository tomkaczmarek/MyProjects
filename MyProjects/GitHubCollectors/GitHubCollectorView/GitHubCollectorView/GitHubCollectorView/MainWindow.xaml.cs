using System.Collections.Generic;
using System.Windows;
using GitHubCollector.Service;
using GitHubCollector.Util;
using GitHubCollector.Collectors;
using GitHubCollector.Factory;
using System.Configuration;
using System;
using System.Reflection;
using System.ComponentModel;

namespace GitHubCollectorView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IList<Commit> commitsList;
        private IList<Commit> filterCommitList;
        private IList<Commit> averageCommitList;
        private ICommitsCollector commits;

        public MainWindow()
        {
            InitializeComponent();
            commits = CollectorFactory.CreateCommitsCollector(userName.Text, repositoryName.Text, new GitHubServiceProvider());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bind();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            IList<string> service = new List<string>();
            service.Add("GitHubServiceProvider");

            this.ddServisList.ItemsSource = ConfigurationManager.AppSettings;
            this.ddServisList.SelectedIndex = 0;
        }

        private void Bind()
        {           
            commitsList = commits.GetCommitsList();
            if (commitsList != null)
            {
                filterCommitList = commits.GetFilteredCommitsList(commitsList);
                averageCommitList = commits.GetAverageCommitsList(filterCommitList);
                lvAllCommits.ItemsSource = commitsList;
                lvFilterCommits.ItemsSource = filterCommitList;
                lvAverageCommits.ItemsSource = averageCommitList;
            }
            else
                MessageBox.Show("Page is not exist!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var d = commits.GetRepositorys(userName.Text, new GitHubServiceProvider());
        }
    }
}
