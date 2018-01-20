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

        public async Task<GHRepo> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<GHRepo>> RetrieveAsync()
        {          
            return await _dbContext.GHRepos.ToListAsync();
        }

        public async Task<GHRepo> SaveAsync(GHRepo ghrepo)
        {            
            _dbContext.Add(ghrepo);
            await _dbContext.SaveChangesAsync();
            return ghrepo;
        }

        public async Task<GHRepo> SaveAsync(int id, GHRepo ghrepo)
        {
            throw new NotImplementedException();
        }

        public bool Exists(GHRepo ghrepo)
        {
            throw new NotImplementedException();
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
    }
}
