using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue;

namespace WebMaze.Models.Morgue
{
    public class DataForShowReportViewModel
    {
       public ForensicReportViewModel Report { get; set; }
       public RegisterCardForMorgueViewModel Corpse { get; set; }
    }
}
