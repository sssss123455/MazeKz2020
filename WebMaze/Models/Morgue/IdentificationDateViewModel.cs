using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage ="Укажите дату опознания")]
        [Remote(action: "CheckDateForIdentification", controller: "Morgue", ErrorMessage = "Дата занята", HttpMethod = "POST")]
        public DateTime DateOfIdentification { get; set; }
        public bool IsDateSet { get; set; }
        public long CorpseId { get; set; }
    }
}
