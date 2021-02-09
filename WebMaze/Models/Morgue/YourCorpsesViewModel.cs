using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Morgue
{
    public class YourCorpsesViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Имя умершего (погибшего)")]
        public string NameCorpse { get; set; }
        [Display(Name = "Фамилия умершего (погибшего)")]
        public string SurnameCorpse { get; set; }
        [Display(Name = "Дата смерти")]
        public DateTime DateOfDeath { get; set; }
    }
}
