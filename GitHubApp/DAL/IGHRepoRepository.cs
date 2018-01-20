using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoRepository
    {
        GHRepo Create();
        List<GHRepo> Retrieve();
        GHRepo Save(GHRepo ghrepo);
        GHRepo Save(int id, GHRepo ghrepo);
        bool Exists(GHRepo ghrepo);
    }
}
