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
            Show(list, "Show All Records in Original order");
           

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Show All Records Sorted by Name");
            Console.WriteLine("---------------------------------");

            var myList = list.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            foreach (var value in myList)
            {
                Console.WriteLine(value);
            }


            Console.WriteLine();
            Console.WriteLine();

            dictList.Delete(3);
            Show(list,"After Deletion ");
            Console.WriteLine();
            Console.WriteLine();

            Product product = new Product() { Id = 16, Name = "Battery", Category = "Electronics", Price = 18.50m };
            dictList.Insert(product);
            Show(list, "New Product Added");
            Console.WriteLine();
            Console.WriteLine();


            Product productToUpdate = new Product() { Id = 2, Category = "Furniture", Name = "Desk", Price = 155.70m };
            dictList.Update(productToUpdate);
            Show(list, "Product Updated");
            Console.WriteLine();
            Console.WriteLine();


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

            Product p1 = new Product(); // this product already exists in the collection and we get msg product exist in the collection
            // but if we change p2.Price to 401.00 it will be added to the collection
            p1.Id = 10;
            p1.Name = "Telephone";
            p1.Price = 400.00m;
            p1.Category = "GSM";
            
            Product p2 = new Product();
            p2.Id = 10;
            p2.Name = "Telephone";
            p2.Price = 400.00m;
            p2.Category = "Samsung";
           

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
                dictList.Insert(p2);
                Show(list, "Added with Equals method");
                Console.WriteLine();
                Console.WriteLine();
            }
            //Console.WriteLine(p1.Equals(p2));

            if (dictList.Find(2))
            {
                Console.WriteLine("Record Found in the collection");
            }
            else
            {
                Console.WriteLine("Record is NOT Found in the collection");
            }


            var category = dictList.GetAllByCategory("Printer"); 
            Show(category, "Products by one Category");
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadLine();

        }

        private static void Show(Dictionary<int, Product> dictList, string parameter)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(parameter);
            Console.WriteLine("---------------------------------------");
            foreach (var item in dictList)
            {
                Console.WriteLine(item);
            }
        }

        
}
}
