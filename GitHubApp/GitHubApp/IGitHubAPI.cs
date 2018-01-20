using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.GitHubApp
{
    public interface IGitHubAPI
    {
        Task<string> GetRepositoriesAsync(string languages);
    }
}
