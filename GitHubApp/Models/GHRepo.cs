using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Models
{     
    public class GHRepo
    {        
        [Range(1, int.MaxValue)]        
        public int id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string name { get; set; }
        [DisplayName("Nome Completo")]
        public string full_name { get; set; }     
        [Range(1, int.MaxValue)]
        public int owner_id { get; set; }

        [ForeignKey("owner_id")]
        public virtual GHRepoOwner owner { get; set; }

        public bool @private { get; set; }
        [DisplayName("URL")]
        public string html_url { get; set; }
        [DisplayName("Descrição")]
        public string description { get; set; }
        public bool fork { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime created_at { get; set; }
        [DisplayName("Última Atualização")]
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }        
        public int stargazers_count { get; set; }
        [DisplayName("Número de Observadores")]
        public int watchers_count { get; set; }
        [DisplayName("Linguagem")]
        public string language { get; set; }
        [DisplayName("Pontos")]
        public double score { get; set; }
    }
}
