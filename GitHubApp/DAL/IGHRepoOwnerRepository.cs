﻿using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.DAL
{
    public interface IGHRepoOwnerRepository
    {        
        Task<List<GHRepoOwner>> RetrieveAsync();
        Task<GHRepoOwner> RetrieveAsync(int id);
        Task RemoveAsync(List<GHRepoOwner> owners);
    }
}
