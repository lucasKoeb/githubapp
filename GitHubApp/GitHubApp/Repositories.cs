using GitHubApp.DAL;
using GitHubApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.GitHubApp
{
    public class Repositories
    {
        private readonly IGHRepoRepository _GHRepoRepository;
        private readonly IGHRepoOwnerRepository _GHRepoOwnerRepository;
        private readonly IGitHubAPI _api;

        public Repositories(IGHRepoRepository GHRepoRepository, IGHRepoOwnerRepository GHRepoOwnerRepository, IGitHubAPI api)
        {
            _GHRepoRepository = GHRepoRepository;
            _GHRepoOwnerRepository = GHRepoOwnerRepository;
            _api = api;
        }

        public List<GHRepo> DeserializeJson(string json)
        {
            dynamic values = JsonConvert.DeserializeObject<dynamic>(json);
            return values.items.ToObject<List<GHRepo>>();
        }

        public Task<List<GHRepo>> RetrieveAsync(string language = "")
        {                        
            return _GHRepoRepository.RetrieveAsync(language);
        }

        public async Task Import(List<string> languages)
        {
            List<GHRepo> repositories = new List<GHRepo>();
            foreach (var language in languages)
            {               
                repositories.AddRange(DeserializeJson(await _api.GetRepositoriesAsync(language)).ToList());                               
            }
            await _GHRepoRepository.SaveAsync(repositories);
        }

        public async Task DeleteAsync(int id)
        {
            await _GHRepoRepository.RemoveAsync(id);
        }

        public async Task DeleteAsync()
        {
            await _GHRepoRepository.RemoveAsync(await _GHRepoRepository.RetrieveAsync());
            await _GHRepoOwnerRepository.RemoveAsync(await _GHRepoOwnerRepository.RetrieveAsync());
        }

        public async Task<GHRepo> FindAsync(int id)
        {
            return await _GHRepoRepository.RetrieveAsync(id);            
        }

        public async Task<PaginatedList<GHRepo>> RetrieveAsync(int? current_page, string language = "")
        {
            int page_size = 10;
            return await _GHRepoRepository.RetrieveAsync(page_size, current_page, language);
        }
    }
}
