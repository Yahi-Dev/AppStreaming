using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveSeriesViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Debe colocar el nombre de la Serie")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Debe colocar la informacion de la Serie")]
        public string Info { get; set; }


        [Required(ErrorMessage = "Debe colocar una description breve del contenido para la previsualizacion")]
        public string DescriptionBreve { get; set; }


        [Required(ErrorMessage = "Debe colocar la fecha de salida de la serie")]
        public int FechaSalida { get; set; }



        [Required(ErrorMessage = "Debe colocar el modo del contenido ")]
        public string ModeSerie { get; set; }




        [Range(1,int.MaxValue,ErrorMessage = "Debe seleccionar una productora representable")]
        public int ProdId { get; set; }



        [Range(1, int.MaxValue,ErrorMessage = "Debe seleccionar un genero primario")]
        public int GenId1 { get; set; }



        public int? GenId2 { get; set; }




        [Required(ErrorMessage = "Debe colocar una imagen de portada")]
        public string ImagePortada { get; set; }


        [Required(ErrorMessage = "Debe colocar el video de la serie")]
        public string VideoSerie { get; set;}


        public List<ListProductoras> ListProductoras { get; set;} = new List<ListProductoras>();
        public List<Generos> ListGeneros { get; set;} = new List<Generos>();
    }
}
