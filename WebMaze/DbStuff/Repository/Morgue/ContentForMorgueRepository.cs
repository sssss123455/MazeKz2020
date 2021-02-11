using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class ContentForMorgueRepository : BaseRepository<ContentForMorgue>
    {
        public ContentForMorgueRepository(WebMazeContext context) : base(context)
        {

        }
        public ContentForMorgue GetContent()
        {
            return dbSet.SingleOrDefault();
        }
    }
}
