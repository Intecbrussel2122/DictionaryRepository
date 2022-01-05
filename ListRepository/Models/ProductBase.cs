using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Models
{
    public class ProductBase:CommonBase, IComparable<ProductBase>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public ProductBase(int id, string name, decimal price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }
        public override string ToString()
        {
            return $"{Id,-10} {Name, -15} {Category, -15} {Price, -20}";
        }
        public string GetIdAndName
        {
            get
            {
                return Id + Name;
            }
        }
        public override bool Equals(object obj) // if this method and GetHachcode is commented the program will never find the product
        {

            var product = obj as ProductBase; // cast obj to Product
            // If the passed object is null
            if (product == null)
            {
                return false;
            }
            // if object is not Product
            if (!(product is ProductBase))
            {
                return false;
            }
            // old syntax if we dont use var product = obj as Product
            //return (this.Name == ((Product)obj).Id)
            //    && (this.Price == ((Product)obj).Name);

            // otherwise compare and return 
            //return (this.Name == (product).Id)
            //    && (this.Price == (product).Name);
            return GetIdAndName == product.GetIdAndName; // this property is beter than the lines above
        }
        // always implement 
        public override int GetHashCode()
        {
            //altGR + 6 = ^
            //return Id.GetHashCode() ^ Name.GetHashCode(); //Bitwise XOR operator return 0 if the operands are equal and 1 if the aoperands are different
            return GetIdAndName.GetHashCode();// this is another way to test through property GetIdAndName
        }

        public int CompareTo(ProductBase other)
        {
            // Alphabetic sort 
            return this.Name.CompareTo(other.Name);
        }

        public string GetCode()
        {
            // inserted PadRight(3) to avoid crashes if Category or Name are shorter than 3 characters
           // return (Id + Name.PadRight(3).Substring(0, 3).ToUpper() + Category.PadRight(3).Substring(0,4).Replace(" ", "_").ToUpper());
            return (Id + Name.PadRight(3).Substring(0, 3).Replace(" ","_").ToUpper() + Category.PadRight(3).Substring(0,4).Replace(" ", "_").ToUpper());
        }
    }
}
