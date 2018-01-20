using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoOwnerRepository
    {
        Task<GHRepoOwner> CreateAsync();
        Task<List<GHRepoOwner>> RetrieveAsync();
        Task<GHRepoOwner> SaveAsync(GHRepoOwner ghrepo);
        Task<GHRepoOwner> SaveAsync(int id, GHRepoOwner ghrepo);
        bool Exists(GHRepoOwner ghrepo);
    }
}
