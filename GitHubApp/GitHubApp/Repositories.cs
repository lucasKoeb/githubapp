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

        public Task<GHRepo> RetrieveAsync(int id)
        {
            return _GHRepoRepository.RetrieveAsync(id);
        }        

        public GHRepo BeforeAdd(GHRepo ghrepo)
        {
            if (_GHRepoOwnerRepository.Exists(ghrepo.owner))
            {
                ghrepo.owner_id = ghrepo.owner.id;
                ghrepo.owner = null;
            }
            return ghrepo;
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
    }
}
