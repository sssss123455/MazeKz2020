using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WebMaze.DbStuff.Model.Morgue.RitualService;

namespace WebMaze.Models.Morgue
{
    public class RitualServiceViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Тип захоронения")]
        public  BurialTypes BurialType { get; set; }
        [Display(Name ="Цена")]
        public  decimal Price { get; set; }
        [Display(Name ="Описание")]
        public  string Description { get; set; }
        [Display(Name ="Фото")]
        public  string UrlPhoto { get; set; }
        
        public IFormFile Photo { get; set; }
    }
}
