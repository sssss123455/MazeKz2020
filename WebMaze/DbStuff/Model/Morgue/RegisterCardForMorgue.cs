using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Morgue
{
    public class RegisterCardForMorgue:BaseModel
    {
        public virtual CitizenUser Corpse { get; set; }
        public virtual Genders Gender { get; set; }
        public virtual DateTime DateOfDeath { get; set; }
        public virtual DateTime DateOfRegister { get; set; }
        public virtual string BodyDamage { get; set; }
        public virtual string ThingsFromBody { get; set; }
        public virtual ForensicReport ForensicReport { get; set; }
        public virtual BodyIdentificationReport BodyIdentificationReport { get; set; }
        public virtual Funeral Funeral { get; set; }
        public enum Genders 
        {
        [Display(Name ="Мужской")]
        male,
        [Display(Name ="Женский")]
        female
        };
    }
}
