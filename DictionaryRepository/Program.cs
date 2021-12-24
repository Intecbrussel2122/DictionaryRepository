using DictionaryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictList = ProductManager.SelectAll();
            Show(dictList);
            
            ProductManager.Delete(3);
            Show(dictList);

            Product product = new Product() { Id = 6, Name = "Battery", Category = "Electronics", Price = 18.50m };
            ProductManager.Insert(product);
            Show(dictList);

            Product productToUpdate = new Product() { Id = 2, Category = "Furniture", Name = "Desk", Price = 155.70m };
            ProductManager.Update(productToUpdate);
            Show(dictList);
        }

        private static void Show(Dictionary<int, Product> dictList)
        {
            Console.WriteLine("---------------------------------------");
            foreach (var item in dictList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
