namespace DataBase.Models
{
    public class Productora
    {
        public virtual int ProductoraId { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int AnioFundacion { get; set; }
        public string ImageProd {  get; set; }


        public ICollection<Series>? Series { get; set; }
    }
}