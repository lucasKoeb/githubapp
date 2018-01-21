using GitHubApp.GitHubApp;
using GitHubApp.Models;
using System.Collections.Generic;
using Xunit;
using Moq;
using GitHubApp.DAL;
using System.Threading.Tasks;

namespace GitHubAppTests.GitHubApp
{
    public class RepositoriesTests
    {       
        [Fact]
        public void ShouldDeserializeToModel()
        {
            var GHRepoRepository = new Mock<IGHRepoRepository>();
            var GHRepoOwnerRepository = new Mock<IGHRepoOwnerRepository>();
            var GitHubAPI = new Mock<IGitHubAPI>();

            Repositories repositories = new Repositories(GHRepoRepository.Object, GHRepoOwnerRepository.Object, GitHubAPI.Object);
            List<GHRepo> repositorios = repositories.DeserializeJson(TestFixture.sample_json_data);
            Assert.Equal(2, repositorios.Count);
        }
    }
}
