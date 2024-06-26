﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveGeneroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del genero")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Debe colocar una imagen representativa del genero")]
        public string ImagePath { get; set; }
    }
}
