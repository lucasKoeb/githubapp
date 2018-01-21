using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Text.Encodings.Web;
  
namespace GitHubApp.GitHubApp
{
    public class GitHubAPI : IGitHubAPI
    {
                
        public async Task<string> GetRepositoriesAsync(string language)
        {
            HttpClient httpClient = new HttpClient();
            string path = "search/repositories";
            string query = $"?q=language:{System.Net.WebUtility.UrlEncode(language.ToLower())}&sort=stars&order=desc";
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
