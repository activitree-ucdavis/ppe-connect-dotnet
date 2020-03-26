using System.Collections.Generic;

namespace HackCOVID19.Models
{
    class Producer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}