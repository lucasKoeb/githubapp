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

        [Fact]
        public void ImportShouldRetrieveRepositoriesForEveryLanguageAndSaveOnce()
        {
            var GHRepoRepository = new Mock<IGHRepoRepository>();
            var GHRepoOwnerRepository = new Mock<IGHRepoOwnerRepository>();
            var GitHubAPI = new Mock<IGitHubAPI>();
            GitHubAPI.Setup(a => a.GetRepositoriesAsync(It.IsAny<string>())).Returns(Task.FromResult(TestFixture.sample_json_data));

            List<string> languages = new List<string>()
            {
                "JavaScript",
                "Java",
                "C#"
            };

            Repositories repositories = new Repositories(GHRepoRepository.Object, GHRepoOwnerRepository.Object, GitHubAPI.Object);
            repositories.Import(languages);
            GitHubAPI.Verify(a => a.GetRepositoriesAsync(It.IsAny<string>()), Times.Exactly(languages.Count));
            GHRepoRepository.Verify(r => r.SaveAsync(It.IsAny<List<GHRepo>>()), Times.Once());
        }        
    }
}
