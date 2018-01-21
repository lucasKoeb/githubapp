using GitHubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public class GHRepoRepository : IGHRepoRepository
    {
        private GitHubAppContext _dbContext { get; set; }

        public GHRepoRepository([FromServices] GitHubAppContext context)
        {
            _dbContext = context;
        }     

        public async Task<List<GHRepo>> RetrieveAsync(string language = "")
        {          
            if (String.IsNullOrEmpty(language))
            {
                return await _dbContext.GHRepos.ToListAsync();
            }
            else
            {
                return await _dbContext.GHRepos.Where(r => r.language == language).ToListAsync();
            }
        }

        public async Task<GHRepo> RetrieveAsync(int id)
        {
            GHRepo ghrepo = await _dbContext.GHRepos.SingleOrDefaultAsync(m => m.id == id);
            if (ghrepo == null)
            {
                return null;
            }

            return ghrepo;
        }
        
        public async Task SaveAsync(List<GHRepo> repositories)
        {
            await _dbContext.AddRangeAsync(repositories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var gHRepo = await _dbContext.GHRepos.SingleOrDefaultAsync(m => m.id == id);
            _dbContext.GHRepos.Remove(gHRepo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(List<GHRepo> repositories)
        {
            _dbContext.RemoveRange(repositories);            
            await _dbContext.SaveChangesAsync();
        }
    }
}
