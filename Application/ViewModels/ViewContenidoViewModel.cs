using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ViewContenidoViewModel
    {
        public string Title { get; set; }
        public string Info { get; set; }

        public int FechaSalida { get; set; }
        public string ModeSerie { get; set; }

        public string Prod { get; set; }

        public string Gen1 { get; set; }

        public string Gen2 { get; set; }
        public string VideoSerie { get; set; }
    }
}
