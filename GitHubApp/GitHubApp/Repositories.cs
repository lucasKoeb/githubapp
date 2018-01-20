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
        public Repositories(IGHRepoRepository GHRepoRepository, IGHRepoOwnerRepository GHRepoOwnerRepository)
        {
            _GHRepoRepository = GHRepoRepository;
            _GHRepoOwnerRepository = GHRepoOwnerRepository;
        }

        public List<GHRepo> DeserializeJson(string json)
        {
            dynamic values = JsonConvert.DeserializeObject<dynamic>(json);
            return values.items.ToObject<List<GHRepo>>();
        }

        internal Task<List<GHRepo>> RetrieveAsync()
        {
            return _GHRepoRepository.RetrieveAsync();
        }

        internal Task<GHRepo> RetrieveAsync(int id)
        {
            return _GHRepoRepository.RetrieveAsync(id);
        }

        public GHRepo Save(GHRepo ghrepo)
        {
            ghrepo = BeforeAdd(ghrepo);
            _GHRepoRepository.SaveAsync(ghrepo);
            return ghrepo;
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
    }
}
