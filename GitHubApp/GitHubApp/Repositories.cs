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
        private readonly IGHRepoRepository _repository;
        public Repositories(IGHRepoRepository repository)
        {
            _repository = repository;
        }
        public List<GHRepo> DeserializeJson(string json)
        {
            dynamic values = JsonConvert.DeserializeObject<dynamic>(json);
            return values.items.ToObject<List<GHRepo>>();
        }

        public void Save(GHRepo GHRepo)
        {
            _repository.Save(GHRepo);
        }
    }
}
