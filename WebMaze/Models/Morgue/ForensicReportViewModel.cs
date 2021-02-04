using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.Models.Morgue
{
    public class ForensicReportViewModel
    {
        [Display(Name="Причина смерти")]
        [Required(ErrorMessage ="Укажите причину смерти")]
        public  string CauseOfDeath { get; set; }
        [Display(Name ="Комментарий")]
        public  string Comment { get; set; }
        [Display(Name ="Дата проведения")]
        public  DateTime DateOfForensic { get; set; }
        [Display(Name = "Данные патологоанатома")]
        public CitizenUser Pathologist { get; set; }
        public  bool IsReportRecorded { get; set; }
        public long CorpseId { get; set; }

    }
}
