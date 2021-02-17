using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.Morgue
{
    public class FuneralViewModel
    {
        [Display(Name = "Дата похорон")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Remote(action: "CheckDate", controller: "Morgue",ErrorMessage ="Дата занята", HttpMethod = "POST")]
        [Editable(true)]
        public  DateTime DateOfFuneral { get; set; }
        [Display(Name = "Описание похорон")]
        public  long RitualServiceId { get; set; }
        [Display(Name = "Комментарий")]
        [Required]
        public  string Comment { get; set; }
        public  long CorpseId { get; set; }
    }
}
