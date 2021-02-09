using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class RegisterCardForMorgueRepository : BaseRepository<RegisterCardForMorgue>
    {
        public RegisterCardForMorgueRepository(WebMazeContext context) : base(context)
        {
        }
        public List<RegisterCardForMorgue> GetListOfAllCorpsesOfIdentifier(long identifyingPersonId)
        {
            return dbSet.Where(x=>x.BodyIdentificationReport.IdentifyingPerson.Id == identifyingPersonId && x.Funeral.DateOfFuneral==null).ToList();
        }
    }  
}
