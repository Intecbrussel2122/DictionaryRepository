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
            var dictList = new ProductManager();
            var list  = dictList.SelectAll();

            Show(list);
            
            dictList.Delete(3);
            Show(list);

            Product product = new Product() { Id = 6, Name = "Battery", Category = "Electronics", Price = 18.50m };
            dictList.Insert(product);
            Show(list);

            Product productToUpdate = new Product() { Id = 2, Category = "Furniture", Name = "Desk", Price = 155.70m };
            dictList.Update(productToUpdate);
            Show(list);

            var result = dictList.SelectSingle(2);
            Console.WriteLine("This is from getsingle");
            Console.WriteLine(result.Id + " " + result.Name + " " + result.Category + " " + result.Price);

            try
            {
                result = dictList.GetWithTryParse(11);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
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
