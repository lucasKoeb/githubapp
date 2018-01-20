using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoRepository
    {
        Task<GHRepo> CreateAsync();
        Task<List<GHRepo>> RetrieveAsync();
        Task<GHRepo> RetrieveAsync(int id);
        Task<GHRepo> SaveAsync(GHRepo ghrepo);
        Task<GHRepo> SaveAsync(int id, GHRepo ghrepo);
        bool Exists(GHRepo ghrepo);
    }
}
