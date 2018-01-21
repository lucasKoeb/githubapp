using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitHubApp.Models;
using GitHubApp.GitHubApp;
using Newtonsoft.Json;
using GitHubApp.DAL;
using Microsoft.Extensions.Options;

namespace GitHubApp.Controllers
{
    public class GHReposController : Controller
    {
        private Repositories _repositories;
        private List<string> _languages;

        public GHReposController(IGHRepoRepository ghRepoRepository, IGHRepoOwnerRepository ghRepoOwnerRepository, IOptions<LanguageConfiguration> languages, IGitHubAPI api)
        {
            _repositories = new Repositories(ghRepoRepository, ghRepoOwnerRepository, api);
            _languages = languages.Value.Languages;
        }

        // GET: GHRepos
        public async Task<IActionResult> Index(string language)
        {
            ViewData["Languages"] = _languages;
            List<GHRepo> viewModel = null;

            if (!String.IsNullOrEmpty(language))
            {
                ViewData["SelectedLanguage"] = language;
                viewModel = await _repositories.RetrieveAsync(language);
            }
            else
            {
                viewModel = await _repositories.RetrieveAsync();                                
            }
            return View(viewModel);
        }

        // GET: GHRepos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            GHRepo viewModel = await _repositories.FindAsync((int) id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: GHRepos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghrepo = await _repositories.FindAsync((int) id);

            if (ghrepo == null)
            {
                return NotFound();
            }

            return View(ghrepo);
        }

        // POST: GHRepos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositories.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: GHRepos/Import
        public async Task<IActionResult> Import()
        {
            await _repositories.Import(_languages);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteImported()
        {
            await _repositories.DeleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
