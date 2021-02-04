using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class ForensicReport:BaseModel
    {

        public virtual string CauseOfDeath { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime DateOfForensic { get; set; }
        public virtual CitizenUser Pathologist { get; set; }
        public virtual bool IsReportRecorded { get; set; }
        public virtual RegisterCardForMorgue Corpse { get; set; }
        public virtual long CorpseId { get; set; }
    }
}
