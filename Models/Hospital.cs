using System.Collections.Generic;

namespace HackCOVID19.Models
{
    class Hospital
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public List<Product> ProductsNeeded { get; set; }
    }
}