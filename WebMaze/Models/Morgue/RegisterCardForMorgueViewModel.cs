using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue;

namespace WebMaze.Models.Morgue
{
    public class RegisterCardForMorgueViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Имя умершего (погибшего)")]
        public  string Name { get; set; }
        [Display(Name = "Фамилия умершего (погибшего)")]
        public  string Surname { get; set; }
        [Display(Name = "Пол")]
        public  Genders Gender { get; set; }
        [Display(Name = "Дата смерти")]
        public  DateTime DateOfDeath { get; set; }
        [Display(Name = "Дата регистрации")]
        public  DateTime DateOfRegister { get; set; }
        [Display(Name = "Наличие повреждений тела умершего")]
        public  string BodyDamage { get; set; }
        [Display(Name = "Наличие  на  теле  умершего  изделий  из  металла,  денег,  ценных  вещей")]
        public  string ThingsFromBody { get; set; }
        [Display(Name ="Дата опознания")]
        public DateTime DateOfIdentification { get; set; }
        public  bool IsReportRecorded { get; set; }
        public bool IsDateSet { get; set; }
        public bool IsIdentified { get; set; }

    }
}
