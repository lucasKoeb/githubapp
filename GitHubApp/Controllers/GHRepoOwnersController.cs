using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitHubApp.DAL;
using GitHubApp.Models;

namespace GitHubApp.Controllers
{
    public class GHRepoOwnersController : Controller
    {
        private readonly IGHRepoOwnerRepository _repository;

        public GHRepoOwnersController(IGHRepoOwnerRepository repository)
        {
            _repository = repository;
        }        

        // GET: GHRepoOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghrepoOwner = await _repository.RetrieveAsync((int)id);

            if (ghrepoOwner == null)
            {
                return NotFound();
            }

            return View(ghrepoOwner);
        }        
    }
}
