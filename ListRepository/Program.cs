using ListRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get All
            ComputerManager cm = new ComputerManager();
            var resultAll = cm.SelectAll();

            //List<ProductBase> resultAll = cm.SelectAll();
            //IEnumerable<ProductBase> resultAll = cm.SelectAll();
            //IList<ProductBase> resultAll = cm.SelectAll();
            //ICollection<ProductBase> resultAll = cm.SelectAll();

            Show(resultAll, "Show all");
            Console.WriteLine();
            Console.WriteLine();


            //Create new product and insert it in the collection
            Computer p0 = new Computer(12, "IBM", 900.00m, "Laptop");
            cm.Insert(p0);

            if (resultAll == null) // check for lazy loading, if resultAll is null initialise it here 
            {
                 resultAll = cm.SelectAll();
            }
            else
            {
                Show(resultAll, "Show after add"); //  otherwise use resultAll here
                Console.WriteLine();
                Console.WriteLine();
            }


            //Find an product
            var found = cm.Find(3);
            Console.WriteLine("Find an product");
            if (found)
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine();
            Console.WriteLine();


            //GetByCategory
            var category = cm.GetAllByCategory("Desktop");
            Show(category, "Show by category");
            Console.WriteLine();


            //Select single
            Console.WriteLine("single record selected");
            var single = cm.SelectSingle(2);
            Console.WriteLine(single.Name);
            Console.WriteLine(single.Category);
            Console.WriteLine(single.Price);


            //removeAt
            cm.Delete(1);
            Console.WriteLine();
            Show(resultAll, "Show after deletion");
            Console.WriteLine();
            Console.WriteLine();


            //Add if not same ID and Name 
            //***********************************************************************
            // create two object of Product to test Equals and hashcode 

            Computer   p1 = new Computer(1, "ThinkPad", 800.00m, "Laptop"); // this product already exists in the collection and we get msg product exist in the collection
                                                                                // but if we change p2.Price to 401.00 it will be added to the collection


            Computer p2 = new Computer(1, "ThinkPad", 800.00m, "Laptop");

            Console.WriteLine("Test with == ");
            Console.WriteLine(p1 == p2); // this will allways give false because reference is different 
            Console.WriteLine("Not Same");  

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Test with Equals method");
            // in other hand the code below will add new product if equals is not true otherwise gives a message Product already exist in the Collection
            var equal = p1.Equals(p2);

            if (equal)
            {
                Console.WriteLine("Product Already exists in the collection");
            }
            else
            {
                ProductBase p = new ProductBase(10, "ThinkPad", 800.00m, "Laptop");
                cm.Insert(p2);
                Show(resultAll, "Added with Equals method");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine("Same");

            Console.WriteLine();
            Console.WriteLine();

            var parts = cm.GetPartOfProductAsString(3);

            Console.WriteLine("From string collection");
            foreach (var item in parts)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(parts.Max(a => a.Price)); // here I do NOT HAVE access to price to make any calculation
            //Console.WriteLine(parts.Sum(a => a.Price));

            Console.WriteLine();
            Console.WriteLine();
            //*************************************************************
           
            var partsDTO = cm.GetPartOfProductDTO();
            Console.WriteLine("From DTO collection");

            foreach (var item in partsDTO)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(partsDTO.Max(a => a.Price)); // here I DO HAVE access to price to make any calculation
            //Console.WriteLine(partsDTO.Sum(a => a.Price)); 

            Console.WriteLine();
            Console.WriteLine();

            // sort by name
            var sort = cm.SelectAll();
            sort.Sort();
            Show(sort, "Sort by Name");


            Console.WriteLine();
            Console.WriteLine();

            // sort by price
            if (sort == null)
            {
                sort = cm.SelectAll();
            }
            else
            {
                sort.Sort(new SortByPrice()); 
            }
            
            
            Show(sort, "Sort by price");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Use GetCode method");
            foreach (var item in sort)
            {
                if (item.Id.ToString().Length > 1)
                {
                    Console.WriteLine(item.GetCode() + item.Price.ToString().PadLeft(22));

                }
                else 
                {
                    Console.WriteLine(item.GetCode() + item.Price.ToString().PadLeft(23));
                }
            }
            Console.ReadLine();
        } 

     
        private static void Show(IEnumerable<Computer> resultAll, string argument)
        {
            Console.WriteLine(argument);
            Console.WriteLine(new string('-',50));
            foreach (var item in resultAll)
            {
                Console.WriteLine(item);
            }
        }
    } 
}
