﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitHubApp.Models;
using GitHubApp.GitHubApp;
using Newtonsoft.Json;

namespace GitHubApp.Controllers
{
    public class GHReposController : Controller
    {
        string sample_json_data = @"
        {
	        'total_count': 2,
	        'incomplete_results': false,
	        'items': [{
			        'id': 58972043,
			        'name': 'ohm-editor',
			        'full_name': 'harc/ohm-editor',
			        'owner': {
				        'login': 'harc',
				        'id': 22809831,
				        'avatar_url': 'https://avatars0.githubusercontent.com/u/22809831?v=4',
				        'gravatar_id': '',
				        'url': 'https://api.github.com/users/harc',
				        'html_url': 'https://github.com/harc',
				        'followers_url': 'https://api.github.com/users/harc/followers',
				        'following_url': 'https://api.github.com/users/harc/following{/other_user}',
				        'gists_url': 'https://api.github.com/users/harc/gists{/gist_id}',
				        'starred_url': 'https://api.github.com/users/harc/starred{/owner}{/repo}',
				        'subscriptions_url': 'https://api.github.com/users/harc/subscriptions',
				        'organizations_url': 'https://api.github.com/users/harc/orgs',
				        'repos_url': 'https://api.github.com/users/harc/repos',
				        'events_url': 'https://api.github.com/users/harc/events{/privacy}',
				        'received_events_url': 'https://api.github.com/users/harc/received_events',
				        'type': 'Organization',
				        'site_admin': false
			        },
			        'private': false,
			        'html_url': 'https://github.com/harc/ohm-editor',
			        'description': 'An IDE for the Ohm language (JavaScript edition)',
			        'fork': false,
			        'url': 'https://api.github.com/repos/harc/ohm-editor',
			        'forks_url': 'https://api.github.com/repos/harc/ohm-editor/forks',
			        'keys_url': 'https://api.github.com/repos/harc/ohm-editor/keys{/key_id}',
			        'collaborators_url': 'https://api.github.com/repos/harc/ohm-editor/collaborators{/collaborator}',
			        'teams_url': 'https://api.github.com/repos/harc/ohm-editor/teams',
			        'hooks_url': 'https://api.github.com/repos/harc/ohm-editor/hooks',
			        'issue_events_url': 'https://api.github.com/repos/harc/ohm-editor/issues/events{/number}',
			        'events_url': 'https://api.github.com/repos/harc/ohm-editor/events',
			        'assignees_url': 'https://api.github.com/repos/harc/ohm-editor/assignees{/user}',
			        'branches_url': 'https://api.github.com/repos/harc/ohm-editor/branches{/branch}',
			        'tags_url': 'https://api.github.com/repos/harc/ohm-editor/tags',
			        'blobs_url': 'https://api.github.com/repos/harc/ohm-editor/git/blobs{/sha}',
			        'git_tags_url': 'https://api.github.com/repos/harc/ohm-editor/git/tags{/sha}',
			        'git_refs_url': 'https://api.github.com/repos/harc/ohm-editor/git/refs{/sha}',
			        'trees_url': 'https://api.github.com/repos/harc/ohm-editor/git/trees{/sha}',
			        'statuses_url': 'https://api.github.com/repos/harc/ohm-editor/statuses/{sha}',
			        'languages_url': 'https://api.github.com/repos/harc/ohm-editor/languages',
			        'stargazers_url': 'https://api.github.com/repos/harc/ohm-editor/stargazers',
			        'contributors_url': 'https://api.github.com/repos/harc/ohm-editor/contributors',
			        'subscribers_url': 'https://api.github.com/repos/harc/ohm-editor/subscribers',
			        'subscription_url': 'https://api.github.com/repos/harc/ohm-editor/subscription',
			        'commits_url': 'https://api.github.com/repos/harc/ohm-editor/commits{/sha}',
			        'git_commits_url': 'https://api.github.com/repos/harc/ohm-editor/git/commits{/sha}',
			        'comments_url': 'https://api.github.com/repos/harc/ohm-editor/comments{/number}',
			        'issue_comment_url': 'https://api.github.com/repos/harc/ohm-editor/issues/comments{/number}',
			        'contents_url': 'https://api.github.com/repos/harc/ohm-editor/contents/{+path}',
			        'compare_url': 'https://api.github.com/repos/harc/ohm-editor/compare/{base}...{head}',
			        'merges_url': 'https://api.github.com/repos/harc/ohm-editor/merges',
			        'archive_url': 'https://api.github.com/repos/harc/ohm-editor/{archive_format}{/ref}',
			        'downloads_url': 'https://api.github.com/repos/harc/ohm-editor/downloads',
			        'issues_url': 'https://api.github.com/repos/harc/ohm-editor/issues{/number}',
			        'pulls_url': 'https://api.github.com/repos/harc/ohm-editor/pulls{/number}',
			        'milestones_url': 'https://api.github.com/repos/harc/ohm-editor/milestones{/number}',
			        'notifications_url': 'https://api.github.com/repos/harc/ohm-editor/notifications{?since,all,participating}',
			        'labels_url': 'https://api.github.com/repos/harc/ohm-editor/labels{/name}',
			        'releases_url': 'https://api.github.com/repos/harc/ohm-editor/releases{/id}',
			        'deployments_url': 'https://api.github.com/repos/harc/ohm-editor/deployments',
			        'created_at': '2016-05-16T22:24:07Z',
			        'updated_at': '2018-01-02T22:58:29Z',
			        'pushed_at': '2017-11-28T10:36:48Z',
			        'git_url': 'git://github.com/harc/ohm-editor.git',
			        'ssh_url': 'git@github.com:harc/ohm-editor.git',
			        'clone_url': 'https://github.com/harc/ohm-editor.git',
			        'svn_url': 'https://github.com/harc/ohm-editor',
			        'homepage': null,
			        'size': 41450,
			        'stargazers_count': 50,
			        'watchers_count': 50,
			        'language': 'JavaScript',
			        'has_issues': true,
			        'has_projects': true,
			        'has_downloads': true,
			        'has_wiki': true,
			        'has_pages': false,
			        'forks_count': 6,
			        'mirror_url': null,
			        'archived': false,
			        'open_issues_count': 13,
			        'license': {
				        'key': 'mit',
				        'name': 'MIT License',
				        'spdx_id': 'MIT',
				        'url': 'https://api.github.com/licenses/mit'
			        },
			        'forks': 6,
			        'open_issues': 13,
			        'watchers': 50,
			        'default_branch': 'master',
			        'score': 37.791035
		        },
		        {
			        'id': 14723119,
			        'name': 'consulo-javascript',
			        'full_name': 'consulo/consulo-javascript',
			        'owner': {
				        'login': 'consulo',
				        'id': 4450820,
				        'avatar_url': 'https://avatars0.githubusercontent.com/u/4450820?v=4',
				        'gravatar_id': '',
				        'url': 'https://api.github.com/users/consulo',
				        'html_url': 'https://github.com/consulo',
				        'followers_url': 'https://api.github.com/users/consulo/followers',
				        'following_url': 'https://api.github.com/users/consulo/following{/other_user}',
				        'gists_url': 'https://api.github.com/users/consulo/gists{/gist_id}',
				        'starred_url': 'https://api.github.com/users/consulo/starred{/owner}{/repo}',
				        'subscriptions_url': 'https://api.github.com/users/consulo/subscriptions',
				        'organizations_url': 'https://api.github.com/users/consulo/orgs',
				        'repos_url': 'https://api.github.com/users/consulo/repos',
				        'events_url': 'https://api.github.com/users/consulo/events{/privacy}',
				        'received_events_url': 'https://api.github.com/users/consulo/received_events',
				        'type': 'Organization',
				        'site_admin': false
			        },
			        'private': false,
			        'html_url': 'https://github.com/consulo/consulo-javascript',
			        'description': 'Languages: JavaScript',
			        'fork': false,
			        'url': 'https://api.github.com/repos/consulo/consulo-javascript',
			        'forks_url': 'https://api.github.com/repos/consulo/consulo-javascript/forks',
			        'keys_url': 'https://api.github.com/repos/consulo/consulo-javascript/keys{/key_id}',
			        'collaborators_url': 'https://api.github.com/repos/consulo/consulo-javascript/collaborators{/collaborator}',
			        'teams_url': 'https://api.github.com/repos/consulo/consulo-javascript/teams',
			        'hooks_url': 'https://api.github.com/repos/consulo/consulo-javascript/hooks',
			        'issue_events_url': 'https://api.github.com/repos/consulo/consulo-javascript/issues/events{/number}',
			        'events_url': 'https://api.github.com/repos/consulo/consulo-javascript/events',
			        'assignees_url': 'https://api.github.com/repos/consulo/consulo-javascript/assignees{/user}',
			        'branches_url': 'https://api.github.com/repos/consulo/consulo-javascript/branches{/branch}',
			        'tags_url': 'https://api.github.com/repos/consulo/consulo-javascript/tags',
			        'blobs_url': 'https://api.github.com/repos/consulo/consulo-javascript/git/blobs{/sha}',
			        'git_tags_url': 'https://api.github.com/repos/consulo/consulo-javascript/git/tags{/sha}',
			        'git_refs_url': 'https://api.github.com/repos/consulo/consulo-javascript/git/refs{/sha}',
			        'trees_url': 'https://api.github.com/repos/consulo/consulo-javascript/git/trees{/sha}',
			        'statuses_url': 'https://api.github.com/repos/consulo/consulo-javascript/statuses/{sha}',
			        'languages_url': 'https://api.github.com/repos/consulo/consulo-javascript/languages',
			        'stargazers_url': 'https://api.github.com/repos/consulo/consulo-javascript/stargazers',
			        'contributors_url': 'https://api.github.com/repos/consulo/consulo-javascript/contributors',
			        'subscribers_url': 'https://api.github.com/repos/consulo/consulo-javascript/subscribers',
			        'subscription_url': 'https://api.github.com/repos/consulo/consulo-javascript/subscription',
			        'commits_url': 'https://api.github.com/repos/consulo/consulo-javascript/commits{/sha}',
			        'git_commits_url': 'https://api.github.com/repos/consulo/consulo-javascript/git/commits{/sha}',
			        'comments_url': 'https://api.github.com/repos/consulo/consulo-javascript/comments{/number}',
			        'issue_comment_url': 'https://api.github.com/repos/consulo/consulo-javascript/issues/comments{/number}',
			        'contents_url': 'https://api.github.com/repos/consulo/consulo-javascript/contents/{+path}',
			        'compare_url': 'https://api.github.com/repos/consulo/consulo-javascript/compare/{base}...{head}',
			        'merges_url': 'https://api.github.com/repos/consulo/consulo-javascript/merges',
			        'archive_url': 'https://api.github.com/repos/consulo/consulo-javascript/{archive_format}{/ref}',
			        'downloads_url': 'https://api.github.com/repos/consulo/consulo-javascript/downloads',
			        'issues_url': 'https://api.github.com/repos/consulo/consulo-javascript/issues{/number}',
			        'pulls_url': 'https://api.github.com/repos/consulo/consulo-javascript/pulls{/number}',
			        'milestones_url': 'https://api.github.com/repos/consulo/consulo-javascript/milestones{/number}',
			        'notifications_url': 'https://api.github.com/repos/consulo/consulo-javascript/notifications{?since,all,participating}',
			        'labels_url': 'https://api.github.com/repos/consulo/consulo-javascript/labels{/name}',
			        'releases_url': 'https://api.github.com/repos/consulo/consulo-javascript/releases{/id}',
			        'deployments_url': 'https://api.github.com/repos/consulo/consulo-javascript/deployments',
			        'created_at': '2013-11-26T16:54:55Z',
			        'updated_at': '2017-08-23T12:59:04Z',
			        'pushed_at': '2018-01-15T12:01:01Z',
			        'git_url': 'git://github.com/consulo/consulo-javascript.git',
			        'ssh_url': 'git@github.com:consulo/consulo-javascript.git',
			        'clone_url': 'https://github.com/consulo/consulo-javascript.git',
			        'svn_url': 'https://github.com/consulo/consulo-javascript',
			        'homepage': '',
			        'size': 4331,
			        'stargazers_count': 3,
			        'watchers_count': 3,
			        'language': 'Java',
			        'has_issues': true,
			        'has_projects': false,
			        'has_downloads': true,
			        'has_wiki': false,
			        'has_pages': false,
			        'forks_count': 1,
			        'mirror_url': null,
			        'archived': false,
			        'open_issues_count': 3,
			        'license': {
				        'key': 'apache-2.0',
				        'name': 'Apache License 2.0',
				        'spdx_id': 'Apache-2.0',
				        'url': 'https://api.github.com/licenses/apache-2.0'
			        },
			        'forks': 1,
			        'open_issues': 3,
			        'watchers': 3,
			        'default_branch': 'master',
			        'score': 26.007027
		        }
	        ]
        }
        ";

        private readonly GitHubAppContext _context;

        public GHReposController(GitHubAppContext context)
        {
            _context = context;
        }

        // GET: GHRepos
        public async Task<IActionResult> Index()
        {
            var gitHubAppContext = _context.GHRepos.Include(g => g.owner);
            dynamic values = JsonConvert.DeserializeObject<dynamic>(sample_json_data);
            List<GHRepo> r = values.items.ToObject<List<GHRepo>>();
            foreach (var repo in r)
            {
                _context.GHRepos.Add(repo);
            }
            
            _context.SaveChanges();
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
