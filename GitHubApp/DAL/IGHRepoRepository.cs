using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoRepository
    {       
        Task<List<GHRepo>> RetrieveAsync(string language = "");
        Task<PaginatedList<GHRepo>> RetrieveAsync(int page_size, int? current_page, string language = "");
        Task<GHRepo> RetrieveAsync(int id);
        Task SaveAsync(List<GHRepo> repositories);
        Task RemoveAsync(int id);
        Task RemoveAsync(List<GHRepo> repositories);
    }
}
