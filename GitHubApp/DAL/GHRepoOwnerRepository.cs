using GitHubApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public class GHRepoOwnerRepository : IGHRepoOwnerRepository
    {
        private GitHubAppContext _dbContext { get; set; }

        public GHRepoOwnerRepository([FromServices] GitHubAppContext context)
        {
            _dbContext = context;
        }

        public async Task<GHRepoOwner> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public bool Exists(GHRepoOwner ghrepoOwner)
        {
            return _dbContext.GHRepoOwners.Any(e => e.id == ghrepoOwner.id);
        }

        public async Task<List<GHRepoOwner>> RetrieveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GHRepoOwner> SaveAsync(GHRepoOwner ghrepoOwner)
        {
            throw new NotImplementedException();
        }

        public async Task<GHRepoOwner> SaveAsync(int id, GHRepoOwner ghrepoOwner)
        {
            throw new NotImplementedException();
        }
    }
}
