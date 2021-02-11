using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class ContentForMorgue:BaseModel
    {
        public virtual string UrlPhoto { get; set; }
        public virtual string Text { get; set; }
    }
}
