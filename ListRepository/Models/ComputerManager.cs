using ListRepository.Database;
using ListRepository.Interfaces;
using ListRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Models
{
    public class ComputerManager : IRepository
    {
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


        public void Update(ProductBase product)
        {
            ProductBase updateProduct = Data.ProductList[product.Id];
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Category = product.Category;
        }
        public List<ProductBase> GetAllByCategory(string category)
        {
            var result = SelectAll();
            var list = new List<ProductBase>();
            foreach (var item in result)
            {
                if (item.Category == category)
                {
                    list.Add(new Computer(item.Id, item.Name, item.Price, item.Category));
                }
            }
            return list;
        }

        public List<string> GetPartOfProductAsString(int subLength)
        {
            var result = SelectAll();
            var list = new List<string>();
            string name = string.Empty, category = string.Empty;

            for (int i = 0; i < result.Count; i++)
            {

                if (result[i].Name.Length > 2)
                {
                    name = result[i].Name.Substring(0, subLength).ToUpper();
                }
                else
                {
                    name = result[i].Name.Substring(0, result[i].Name.Length).ToUpper();
                    if (name.Length == 1)
                    {
                        name += "  ";
                    }
                    if (name.Length == 2)
                    {
                        name += " ";
                    }

                }

                if (result[i].Category.Length > 3)
                {
                    category = result[i].Category.Substring(0, subLength + 1).ToUpper();
                }
                else
                {
                    category = result[i].Category.Substring(0, result[i].Category.Length).ToUpper();
                }

                list.Add(result[i].Id.ToString() + name + category + "\t\t" + result[i].Price.ToString());
            }
            return list;
        }

        public List<ProductBase> GetPartOfProductDTO()
        {
            var resultAll = SelectAll();
            return resultAll;
        }
    }
}
