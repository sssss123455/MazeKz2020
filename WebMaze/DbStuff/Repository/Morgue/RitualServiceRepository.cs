using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class RitualServiceRepository : BaseRepository<RitualService>
    {
        public RitualServiceRepository(WebMazeContext context) : base(context)
        {
        }
        public List<RitualService> GetWorkingServices()
        {
            return dbSet.Where(x => x.WasDelete != true).ToList();
        }
    }
}
