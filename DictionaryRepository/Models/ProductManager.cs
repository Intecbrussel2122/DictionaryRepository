using DictionaryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository.Models
{
    public static class ProductManager//: IRepository
    {
        public static void Delete(int id)
        {
            Data.ProductList.Remove(id);
        }

        public static void Insert(Product product)
        {
            Data.ProductList.Add(product.Id,product);
        }

        public static Dictionary<int, Product> SelectAll()
        {
            return Data.ProductList;
        }

        public static void Update(Product product)
        {
            Product updateProduct = Data.ProductList[product.Id];
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Category = product.Category;
        }
    }
}
