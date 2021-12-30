using ListRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Database
{
    public class Data
    {
        public static List<ProductBase> ProductList { get; set; }
        static Data()
        {
            ProductList = new List<ProductBase>();
            Computer p1 = new Computer(1, "Asus", 800.00m, "Laptop");
            Computer p2 = new Computer(2, "ThinkPad", 850.00m, "Laptop");
            Computer p3 = new Computer(3, "HP", 500.00m, "Desktop");
            Computer p4 = new Computer(4, "Daewoo", 450.00m, "Desktop");
            Computer p5 = new Computer(4, "Lenovo", 950.00m, "Laptop");


            ProductList.Add(p1);
            ProductList.Add(p2);
            ProductList.Add(p3);
            ProductList.Add(p4);
            ProductList.Add(p5);
        }
    }
}
