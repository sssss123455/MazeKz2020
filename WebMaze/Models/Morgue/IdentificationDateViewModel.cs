using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Morgue
{
    public class IdentificationDateViewModel
    {
        [Display(Name = "Дата опознания")]
        [Required(ErrorMessage = "Вы не указали дату")]
        public DateTime DateOfIdentification { get; set; }
        public bool IsDateSet { get; set; }
        public long CorpseId { get; set; }
    }
}
