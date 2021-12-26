using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price} {Category}";
        }
        public override bool Equals(object obj) // if this method and GetHachcode is commented the program will never find the product
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            // if object is not Product
            if (!(obj is Product))
            {
                return false;
            }
            // otherwise compare and return 
            return (this.Name == ((Product)obj).Name)
                && (this.Price == ((Product)obj).Price);
        }
        // always implement 
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Price.GetHashCode();
        }
    }
}
