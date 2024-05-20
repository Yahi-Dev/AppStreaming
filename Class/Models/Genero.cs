namespace DataBase.Models
{
    public class Genero
    {
        public virtual int GeneroId { get; set; }
        public string Name { get; set; }
        public string ImageGenero { get; set; }
        public ICollection<Series>? Series1 { get; set;}
        public ICollection<Series>? Series2 { get; set;}
    }
}
