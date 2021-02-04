using WebMaze.DbStuff.Model.Morgue;

namespace WebMaze.DbStuff.Repository.Morgue
{
    public class RitualServiceRepository : BaseRepository<RitualService>
    {
        public RitualServiceRepository(WebMazeContext context) : base(context)
        {
        }
    }
}
