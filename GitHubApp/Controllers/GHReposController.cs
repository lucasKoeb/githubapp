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

namespace GitHubApp.Controllers
{
    public class GHReposController : Controller
    {
        private readonly GitHubAppContext _context;
        private readonly IGHRepoRepository _repository;

        public GHReposController(GitHubAppContext context, IGHRepoRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: GHRepos
        public async Task<IActionResult> Index()
        {
            var gitHubAppContext = _context.GHRepos.Include(g => g.owner);                                    
            return View(await gitHubAppContext.ToListAsync());
        }

        // GET: GHRepos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gHRepo = await _context.GHRepos
                .Include(g => g.owner)
                .SingleOrDefaultAsync(m => m.id == id);
            if (gHRepo == null)
            {
                return NotFound();
            }

            return View(gHRepo);
        }

        // GET: GHRepos/Create
        public IActionResult Create()
        {
            ViewData["owner_id"] = new SelectList(_context.GHRepoOwners, "id", "id");
            return View();
        }

        // POST: GHRepos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,full_name,owner_id,private,html_url,description,fork,created_at,updated_at,pushed_at,stargazers_count,watchers_count,language,score")] GHRepo gHRepo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gHRepo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["owner_id"] = new SelectList(_context.GHRepoOwners, "id", "id", gHRepo.owner_id);
            return View(gHRepo);
        }

        // GET: GHRepos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gHRepo = await _context.GHRepos.SingleOrDefaultAsync(m => m.id == id);
            if (gHRepo == null)
            {
                return NotFound();
            }
            ViewData["owner_id"] = new SelectList(_context.GHRepoOwners, "id", "id", gHRepo.owner_id);
            return View(gHRepo);
        }

        // POST: GHRepos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,full_name,owner_id,private,html_url,description,fork,created_at,updated_at,pushed_at,stargazers_count,watchers_count,language,score")] GHRepo gHRepo)
        {
            if (id != gHRepo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gHRepo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GHRepoExists(gHRepo.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["owner_id"] = new SelectList(_context.GHRepoOwners, "id", "id", gHRepo.owner_id);
            return View(gHRepo);
        }

        // GET: GHRepos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gHRepo = await _context.GHRepos
                .Include(g => g.owner)
                .SingleOrDefaultAsync(m => m.id == id);
            if (gHRepo == null)
            {
                return NotFound();
            }

            return View(gHRepo);
        }

        // POST: GHRepos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gHRepo = await _context.GHRepos.SingleOrDefaultAsync(m => m.id == id);
            _context.GHRepos.Remove(gHRepo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GHRepoExists(int id)
        {
            return _context.GHRepos.Any(e => e.id == id);
        }
    }
}
