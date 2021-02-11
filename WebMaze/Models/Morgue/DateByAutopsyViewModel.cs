using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Morgue
{
    public class DateByAutopsyViewModel
    {
        [Display(Name = "Данные со вскрытия")]
        public ForensicReportViewModel Report { get; set; }
        [Display(Name = "Данные при поступлении")]
        public RegisterCardForMorgueViewModel Corpse { get; set; }
    }
}
