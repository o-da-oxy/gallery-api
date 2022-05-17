namespace GalleryApi.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}