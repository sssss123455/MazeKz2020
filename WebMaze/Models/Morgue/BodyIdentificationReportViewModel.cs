using Microsoft.AspNetCore.Mvc;
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
        public DateTime DateOfIdentification { get; set; }
        public bool IsDateSet { get; set; }
        [Display(Name = "ID полицейского")]
        [Required(ErrorMessage = "Введите ID Полицейсеого")]
        [Remote(action: "IsPoliceman", controller: "Morgue", HttpMethod = "POST")]
        public long PoliceOfficerId { get; set; }
        [Display(Name = "Имя полицейского")]
        public string PoliceOfficerName { get; set; }
        [Display(Name = "Фамилия полицейского")]
        public string PoliceOfficerSurname { get; set; }
        [Display(Name = "ID опознающего")]
        [Required(ErrorMessage = "Введите ID опознающего")]
        [Remote(action: "CheckIdentifyingPerson", controller: "Morgue", HttpMethod = "POST")]
        public long IdentifyingPersonId { get; set; }
        [Display(Name = "Имя опознающего")]
        public string IdentifyingPersonName { get; set; }
        [Display(Name = "Фамилия опознающего")]
        public string IdentifyingPersonSurname { get; set; }
        [Display(Name = "Вердикт по опознанию")]
        [Required(ErrorMessage = "Вы не выбрали вердикт")]
        public bool IsIdentified { get; set; }
        [Display(Name = "ID умершего (погибшего)")]
        [Required(ErrorMessage ="Введите ID погибшего")]
        [Remote(action: "CheckCorpse", controller: "Morgue", HttpMethod = "POST")]
        public long UserId { get; set; }
        public long CorpseId { get; set; }
    }
}
