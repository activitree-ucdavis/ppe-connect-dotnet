using System.Collections.Generic;

namespace HackCOVID19.Models
{
    class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}