using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public class GHRepoOwnerRepository : IGHRepoOwnerRepository
    {
        public async Task<GHRepoOwner> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public bool Exists(GHRepoOwner ghrepo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GHRepoOwner>> RetrieveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GHRepoOwner> SaveAsync(GHRepoOwner ghrepo)
        {
            throw new NotImplementedException();
        }

        public async Task<GHRepoOwner> SaveAsync(int id, GHRepoOwner ghrepo)
        {
            throw new NotImplementedException();
        }
    }
}
