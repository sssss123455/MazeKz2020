using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class BodyIdentificationReport:BaseModel
    {
        public virtual DateTime DateOfIdentification { get; set; }
        public virtual bool IsDateSet { get; set; }
        public virtual CitizenUser PoliceOfficer { get; set; }
        public virtual CitizenUser IdentifyingPerson { get; set; }
        public virtual bool IsIdentified { get; set; }
        public virtual RegisterCardForMorgue Corpse { get; set; }
        public virtual long CorpseId { get; set; }
    }
}
