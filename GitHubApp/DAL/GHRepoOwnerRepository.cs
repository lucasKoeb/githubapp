using GitHubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<GHRepoOwner>> RetrieveAsync()
        {
            return await _dbContext.GHRepoOwners.ToListAsync();
        }

        public async Task RemoveAsync(List<GHRepoOwner> owners)
        {
            _dbContext.RemoveRange(owners);
            await _dbContext.SaveChangesAsync();
        }
    }
}
