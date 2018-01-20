using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoOwnerRepository
    {
        GHRepoOwner Create();
        List<GHRepoOwner> Retrieve();
        GHRepoOwner Save(GHRepoOwner ghrepo);
        GHRepoOwner Save(int id, GHRepoOwner ghrepo);
        bool Exists(GHRepoOwner ghrepo);
    }
}
