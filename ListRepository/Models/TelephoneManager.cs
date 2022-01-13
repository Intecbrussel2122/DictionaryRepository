using ListRepository.Database;
using ListRepository.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ListRepository.Models
{
    public class TelephoneManager : IRepository
    {
        //list done right
        public void Delete(int id)
        {
            Data.ProductList.RemoveAt(id);
        }

        public ProductBase SelectSingle(int id)
        {
            ProductBase product = Data.ProductList[id];
            return product;
        }
        public bool Find(int index)
        {
            var result = Data.ProductList.Find(f => f.Id == index);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Insert(ProductBase product)
        {
            Data.ProductList.Add(product);
        }

        public List<ProductBase> SelectAll()
        {
            return Data.ProductList;
        }

        public void ShowTelephones()
        {
            Console.WriteLine("List of telephones in the stock");
            Console.WriteLine();

            // first shorter way searching specified class type
            foreach (var item in SelectAll().OfType<Telephone>())
            {
                Console.WriteLine(item);
            }

            // second longer way searching specified class type
            //foreach (var item in SelectAll())
            //{
            //    if (item is Telephone)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //Console.WriteLine($"\n\n");
        }

        public void Update(ProductBase product)
        {
            ProductBase updateProduct = Data.ProductList[product.Id];
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Category = product.Category;
        }
    }
}
