using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public class GHRepoOwner
    {
        public int id { get; set; }
        public string login { get; set; }

        public virtual List<GHRepo> repositories { get; set; }
    }
}
