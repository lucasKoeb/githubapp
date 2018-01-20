using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GitHubAppTests.Models
{
    public class GHRepoTests
    {
        [Fact]
        public void ShouldValidateRequiredAttributes()
        {
            GHRepo ghrepo = new GHRepo()
            {
                id = 1,
                name = "my_repo",
                owner_id = 1
            };

            var result = TestHelper.Validate(ghrepo);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldRequireId() {
            GHRepo ghrepo = new GHRepo()
            {
                id = 0,
                name = "my_repo",
                owner_id = 1
            };

            var result = TestHelper.Validate(ghrepo);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void ShouldRequireName() {
            GHRepo ghrepo = new GHRepo()
            {
                id = 1,
                name = null,
                owner_id = 1
            };

            var result = TestHelper.Validate(ghrepo);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void ShouldRequireOwnerId()
        { 
            GHRepo ghrepo = new GHRepo()
            {
                id = 1,
                name = "my_repo",
                owner_id = 0
            };

            var result = TestHelper.Validate(ghrepo);
            Assert.Equal(1, result.Count);
        }
    }
}
