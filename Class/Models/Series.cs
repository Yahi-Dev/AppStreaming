namespace DataBase.Models
{
    public class Series
    {
        public virtual int SerieId { get; set; }
        public string Titulo {  get; set; }
        public string Info { get; set; }
        public string DescriptionBreve { get; set; }
        public int FechaDeSalida { get; set; }
        public string ModeSerie { get; set; }


        public  int ProductoraId { get; set; }
        public Productora Productora { get; set; }


        public int Genero1Id { get; set; }
        public Genero Genero1 { get; set; }

        public int? Genero2Id { get; set; }
        public Genero? Genero2 { get; set; }



        public string ImagePath { get; set; }
        public string VideoPAth { get; set; }



    }
}
                    