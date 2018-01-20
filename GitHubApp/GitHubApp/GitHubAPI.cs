using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubApp.GitHubApp
{
    public class GitHubAPI : IGitHubAPI
    {
        static HttpClient httpClient = new HttpClient();
        
        public async Task<string> GetRepositoriesAsync(string language)
        {
            string path = "search/repositories";
            string query = $"?q=language:{language}";
            httpClient.BaseAddress = new Uri("https://api.github.com/");

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "github-app");

            HttpResponseMessage response = await httpClient.GetAsync(path + query);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();                
            }
            else
            {
                throw new HttpRequestException("Falha ao obter dados do github: " + response.ReasonPhrase);
            }
        }
    }
}
