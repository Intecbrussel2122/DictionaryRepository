using ListRepository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Models
{
    public class Telephone : ProductBase
    {
        public string Meassure { get; set; }
        public Telephone(int id, string name, decimal price, string category, string meassure = "piece") : base(id, name, price, category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Meassure = meassure;
        }

        public override string ToString()
        {
            return $"{Id,-10} {Name,-15} {Category,-15} {Price,-20} {Meassure,-15}";
        }
    }
}
