using GitHubApp.GitHubApp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GitHubAppTests
{
    public class GitHubAPITests
    {
        [Fact]
        public async void ShouldReturnString()
        {
            GitHubAPI api = new GitHubAPI();

            var apiValue = await api.GetRepositoriesAsync("ruby");
            Assert.IsType<String>(apiValue);
            Assert.NotNull(apiValue);
        }
    }
}
