using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ProductDto
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WebID { get; set; }
        public List<Image> Images { get; set; }

        public ProductUpdateDTO()
        {
            Images = new List<Image>();
        }
        public int Rating { get; set; }
        public double Price { get; set; }
        public short Stock { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public List<Comment> Comments { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
