using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class ForensicReportRepository : BaseRepository<ForensicReport>
    {
        public ForensicReportRepository(WebMazeContext context) : base(context)
        {
        }
        public ForensicReport GetReport(long id)
        {
            return dbSet.SingleOrDefault(x => x.CorpseId == id);
        }
    }  
}
