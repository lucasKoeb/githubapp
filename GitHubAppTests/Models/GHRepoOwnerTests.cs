using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GitHubAppTests.Models
{
    public class GHRepoOwnerTests
    {
        [Fact]
        public void ShouldValidateRequiredAttributes()
        {
            GHRepoOwner owner = new GHRepoOwner()
            {
                id = 1,
                login = "owner"
            };

            var result = TestHelper.Validate(owner);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ShouldRequireId()
        {
            GHRepoOwner owner = new GHRepoOwner()
            {
                id = 0,
                login = "owner"
            };

            var result = TestHelper.Validate(owner);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void ShouldRequireLogin()
        {
            GHRepoOwner owner = new GHRepoOwner()
            {
                id = 1,
                login = null
            };

            var result = TestHelper.Validate(owner);
            Assert.Equal(1, result.Count);
        }
    }
}
