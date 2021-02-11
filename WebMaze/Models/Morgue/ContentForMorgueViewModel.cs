using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Morgue
{
    public class ContentForMorgueViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Фото")]
        public  string UrlPhoto { get; set; }
        [Display(Name = "Текст")]
        [Required(ErrorMessage ="Заполните текст")]
        public  string Text { get; set; }
        public IFormFile Photo { get; set; }
    }
}
