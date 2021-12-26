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
                result = dictList.GetWithTryParse(2);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            //***********************************************************************
           // create two object of Product to test Equals and hashcode 

            Product p1 = new Product();
            p1.Id = 10;
            p1.Name = "Table";
            p1.Price = 25.00m;
            p1.Category = "Timber";
            
            Product p2 = new Product();
            p1.Id = 10;
            p2.Name = "Table";
            p2.Price = 25.00m;
            p1.Category = "Timber";
           

            //Console.WriteLine(C1 == C2); // this will allways give false because reference is different 
            // in other hand the code below will add new product if equals is not true otherwise gives a message Product already exist in the Collection
            var equal = p1.Equals(p2);

            if (equal)
            {
                Console.WriteLine("Product Already exists in the collection");
            }
            else
            {
                Product p = new Product();
                dictList.Insert(p1);
                Show(list);
            }
            Console.WriteLine(p1.Equals(p2));

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
