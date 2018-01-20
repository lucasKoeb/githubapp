using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public class GHRepoOwner
    {
        [Range(1, int.MaxValue)]
        public int id { get; set; }
        [Required]
        public string login { get; set; }

        public virtual List<GHRepo> repositories { get; set; }
    }
}
