using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public class GitHubAppContext : DbContext
    {
        public GitHubAppContext(DbContextOptions<GitHubAppContext> options) :
            base(options)
        {
        }

        public DbSet<GHRepo> GHRepos { get; set; }
        public DbSet<GHRepoOwner> GHRepoOwners { get; set; }        
    }
}
