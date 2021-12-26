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


        public string GetNameAndPrice
        {
            get 
            { 
                return Name + Price.ToString(); 
            }
            
        }

        public override bool Equals(object obj) // if this method and GetHachcode is commented the program will never find the product
        {
            
            var product  = obj as Product; // cast obj to Product
            // If the passed object is null
            if (product == null)
            {
                return false;
            }
            // if object is not Product
            if (!(product is Product))
            {
                return false;
            }
            // old syntax
            //return (this.Name == ((Product)obj).Name)
            //    && (this.Price == ((Product)obj).Price);

            // otherwise compare and return 
            //return (this.Name == (product).Name)
            //    && (this.Price == (product).Price);
            return GetNameAndPrice == product.GetNameAndPrice; // this property is beter than the line above
        }
        // always implement 
        public override int GetHashCode()
        {
            //return Name.GetHashCode() ^ Price.GetHashCode(); //Bitwise XOR operator return 0 if the operands are equal and 1 if the aoperands are different
            return GetNameAndPrice.GetHashCode();// this is another way to test through property GetNameAndPrice
        }
    }
}
