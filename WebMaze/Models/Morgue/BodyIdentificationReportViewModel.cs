using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.Models.Morgue
{
    public class BodyIdentificationReportViewModel
    {
        public long Id { get; set; }
        [DisplayFormat(DataFormatString ="dd.MM.yyyy HH:mm", ApplyFormatInEditMode = true)]
        public  DateTime DateOfIdentification { get; set; }
        public  bool IsDateSet { get; set; }
        [Display(Name = "ID полицейского")]
        [Required(ErrorMessage ="Вы не указали ID")]
        public  long PoliceOfficerId { get; set; }
        [Display(Name = "Имя полицейского")]
        public string PoliceOfficerName { get; set; }
        [Display(Name = "Фамилия полицейского")]
        public string PoliceOfficerSurname { get; set; }
        [Display(Name = "ID опознающего")]
        [Required(ErrorMessage = "Вы не указали ID")]
        public  long IdentifyingPersonId { get; set; }
        [Display(Name = "Имя опознающего")]
        public string IdentifyingPersonName { get; set; }
        [Display(Name = "Фамилия опознающего")]
        public string IdentifyingPersonSurname { get; set; }
        [Display(Name = "Вердикт по опознанию")]
        [Required(ErrorMessage = "Вы не выбрали вердикт")]
        public  bool IsIdentified { get; set; }
        [Display(Name = "ID умершего (погибшего)")]
        [Required(ErrorMessage = "Введите ID умершего (погибшего)")]
        public long UserId { get; set; }
        public long CorpseId { get; set; }
    }
}
