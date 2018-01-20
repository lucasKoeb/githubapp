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
            Repositories repositories = new Repositories(GHRepoRepository.Object, GHRepoOwnerRepository.Object);
            List<GHRepo> repositorios = repositories.DeserializeJson(TestFixture.sample_json_data);
            Assert.Equal(2, repositorios.Count);
            Assert.NotNull(repositorios[0].owner);

            repositories.Save(repositorios[0]);            
        }         

        [Fact]
        public void ShouldRemoveOwnerIfitExitsAlready()
        {
            var GHRepoRepository = new Mock<IGHRepoRepository>();
            var GHRepoOwnerRepository = new Mock<IGHRepoOwnerRepository>();
            GHRepoOwnerRepository.Setup(r => r.Exists(It.IsAny<GHRepoOwner>())).Returns(true);
            var repositories = new Repositories(GHRepoRepository.Object, GHRepoOwnerRepository.Object);
            GHRepoOwner test_repository_owner = new GHRepoOwner()
            {
                id = 30,
                login = "login"
            };

            GHRepo test_repository = new GHRepo()
            {
                id = 1,
                owner = test_repository_owner
            };

            test_repository = repositories.BeforeAdd(test_repository);

            Assert.Null(test_repository.owner);
            Assert.Equal(30, test_repository.owner_id);
        }

        [Fact]
        public void SaveMethodShouldCallBeforeAdd()
        {
            var GHRepoRepository = new Mock<IGHRepoRepository>();
            var GHRepoOwnerRepository = new Mock<IGHRepoOwnerRepository>();
            GHRepoOwnerRepository.Setup(r => r.Exists(It.IsAny<GHRepoOwner>())).Returns(true);
            var repositories = new Repositories(GHRepoRepository.Object, GHRepoOwnerRepository.Object);
            GHRepoOwner test_repository_owner = new GHRepoOwner()
            {
                id = 30,
                login = "login"
            };
            GHRepo test_repository = new GHRepo()
            {
                id = 1,
                owner = test_repository_owner
            };
            GHRepoRepository.Setup(r => r.SaveAsync(test_repository)).Returns(Task.FromResult(test_repository));

            test_repository = repositories.Save(test_repository);

            Assert.Null(test_repository.owner);
            Assert.Equal(30, test_repository.owner_id);
        }
    }
}
