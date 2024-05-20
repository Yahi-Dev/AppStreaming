using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SeriesViewModel
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string ImagePath { get; internal set; }
        public string Genero1 { get; internal set; }
        public int gn1ID { get; internal set; }
        public int? gn2Id { get; internal set; }
        public string ModeSerie { get; set; }
        public int prodId { get; internal set; }
        public string? Genero2 { get; internal set; }
        public string Productora { get; internal set; }
        public string DescriptionBreve { get; internal set; }
    }
}
