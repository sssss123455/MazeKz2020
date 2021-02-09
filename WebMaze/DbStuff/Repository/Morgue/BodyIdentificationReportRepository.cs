using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class BodyIdentificationReportRepository:BaseRepository<BodyIdentificationReport>
    {
        public BodyIdentificationReportRepository(WebMazeContext context) : base(context)
        {

        }
        public BodyIdentificationReport GetReport(long corpseId)
        {
           return dbSet.SingleOrDefault(x => x.CorpseId == corpseId);
        }
    }
}
