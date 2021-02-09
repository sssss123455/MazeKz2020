using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.Models.Morgue
{
    public class FuneralViewModel
    {
        public  DateTime DateOfFuneral { get; set; }
        public  long RitualServiceId { get; set; }
        public  string Comment { get; set; }
        public  long CorpseId { get; set; }
    }
}
