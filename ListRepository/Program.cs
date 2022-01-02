﻿using ListRepository.Models;
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
            Show(resultAll, "Show all");
            Console.WriteLine();
            Console.WriteLine();


            ProductBase p0 = new ProductBase(12, "IBM", 900.00m, "Laptop");
            cm.Insert(p0);

            Show(resultAll, "Show after add");
            Console.WriteLine();
            Console.WriteLine();


            //Find
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


            //GetByCategory
            var category = cm.GetAllByCategory("Laptop");
            Show(category, "Show by category");
            Console.WriteLine();
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

            ProductBase p1 = new ProductBase(1, "ThinkPad", 800.00m, "Laptop"); // this product already exists in the collection and we get msg product exist in the collection
                                                                                // but if we change p2.Price to 401.00 it will be added to the collection


            ProductBase p2 = new ProductBase(1, "ThinkPad", 800.00m, "Laptop");

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

            //Console.WriteLine(parts.Max(a => a.Price)); // here I do not have access to price to make any calculation
            //Console.WriteLine(parts.Sum(a => a.Price));

            Console.WriteLine();
            Console.WriteLine();
            //*************************************************************
           
            var partsDTO = cm.GetPartOfProductDTO();
            Console.WriteLine("From DTO collection");

            foreach (var item in partsDTO)
            {
                Console.WriteLine(item.IdNameCategory + "\t\t " + item.Price);
            }
            //Console.WriteLine(partsDTO.Max(a => a.Price)); // here I DO HAVE access to price to make any calculation
            //Console.WriteLine(partsDTO.Sum(a => a.Price)); 
            Console.ReadLine();
        } 

     
        private static void Show(List<ProductBase> resultAll, string argument)
        {
            Console.WriteLine(argument);
            Console.WriteLine("-----------------");
            foreach (var item in resultAll)
            {
                Console.WriteLine(item);
            }
        }
    }
}
