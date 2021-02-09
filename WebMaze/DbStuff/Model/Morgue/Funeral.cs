using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class Funeral:BaseModel
    {
        public virtual DateTime DateOfFuneral { get; set; }
        public virtual RitualService RitualService { get; set; }
        public virtual string Comment { get; set; }
        public virtual RegisterCardForMorgue Corpse { get; set; }
        public virtual long CorpseId { get; set; }
            
    }
}
