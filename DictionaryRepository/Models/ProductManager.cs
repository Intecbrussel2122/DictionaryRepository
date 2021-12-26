using DictionaryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository.Models
{
    public class ProductManager : IRepository
    {

        public void Delete(int id)
        {
            Data.ProductList.Remove(id);
        }

        public Product SelectSingle(int id)
        {
            Product product = Data.ProductList[id];
            return product;
        }

        public void Insert(Product product)
        {
            Data.ProductList.Add(product.Id, product);
        }

        public Dictionary<int, Product> SelectAll()
        {
            return Data.ProductList;
        }

        public void Update(Product product)
        {
            Product updateProduct = Data.ProductList[product.Id];
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Category = product.Category;
        }

        public Product GetWithTryParse(int find)
        {
            Product product = null;
            if (Data.ProductList.TryGetValue(find, out Product value))
            {
                product = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Not found");
            }
            return product;
        }
        public bool Find(int find)
        {
            if (Data.ProductList.TryGetValue(find, out Product value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, Product> GetAllByCategory(string category)
        {
            var result = SelectAll();
            var list = new Dictionary<int, Product>();
            foreach (var item in result)
            {
                if (item.Value.Category == category)
                {
                    list.Add(item.Key, item.Value);
                }
            }
            return list;
        }

    }
}
