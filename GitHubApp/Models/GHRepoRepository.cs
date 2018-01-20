using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public class GHRepoRepository : IGHRepoRepository
    {
        private GitHubAppContext _dbContext { get; set; }

        public GHRepoRepository([FromServices] GitHubAppContext context)
        {
            _dbContext = context;
        }

        public GHRepo Create()
        {
            throw new NotImplementedException();
        }

        public List<GHRepo> Retrieve()
        {
            throw new NotImplementedException();
        }

        public GHRepo Save(GHRepo ghrepo)
        {
            _dbContext.Add(ghrepo);
            _dbContext.SaveChanges();
            return ghrepo;
        }

        public GHRepo Save(int id, GHRepo ghrepo)
        {
            throw new NotImplementedException();
        }
    }
}
