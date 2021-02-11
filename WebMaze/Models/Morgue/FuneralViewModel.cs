using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.Models.Morgue
{
    public class FuneralViewModel
    {
        [Display(Name = "Дата похорон")]
        public  DateTime DateOfFuneral { get; set; }
        [Display(Name = "Описание похорон")]
        public  long RitualServiceId { get; set; }
        [Display(Name = "Комментарий")]
        public  string Comment { get; set; }
        public  long CorpseId { get; set; }
    }
}
