using static System.Net.Mime.MediaTypeNames;

namespace ENTITY
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WebID { get; set; }
        public List<Image> Images { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public short Stock { get; set; }
        public int BrandId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
