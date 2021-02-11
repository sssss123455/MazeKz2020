using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Morgue
{
    public class ListOfFuneralViewModel
    {
        [Display(Name = "Похороны")]
        public RitualServiceViewModel Service { get; set; }
        public FuneralViewModel Funeral { get; set; }
        [Display(Name = "Имя умершего (погибшего)")]
        public string NameCorpse { get; set; }
        [Display(Name = "Фамилия умершего (погибшего)")]
        public string SurnameCorpse { get; set; }
        [Display(Name = "Дата рождения умершего (погибшего)")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата смерти умершего (погибшего)")]
        public DateTime DateOfDeath { get; set; }
    }
}
