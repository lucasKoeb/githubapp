using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public interface IGHRepoRepository
    {
        GHRepo Create();
        List<GHRepo> Retrieve();
        GHRepo Save(GHRepo ghrepo);
        GHRepo Save(int id, GHRepo ghrepo);
    }
}
