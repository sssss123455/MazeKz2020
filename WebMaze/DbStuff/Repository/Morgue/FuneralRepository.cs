using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class FuneralRepository:BaseRepository<Funeral>
    {
        public FuneralRepository(WebMazeContext context) : base(context)
        {

        }
    }
}
