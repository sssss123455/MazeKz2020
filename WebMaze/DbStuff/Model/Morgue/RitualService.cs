using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class RitualService:BaseModel
    {
        public virtual BurialTypes BurialType { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Description { get; set; }
        public virtual string UrlPhoto { get; set; }
        public enum BurialTypes
        {
            [Display(Name = "Ингумация")]
            inhumation,
            [Display(Name = "Кремация")]
            cremation
        };
    }
}
