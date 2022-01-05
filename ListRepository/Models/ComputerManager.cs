using ListRepository.Database;
using ListRepository.Interfaces;
using System.Collections.Generic;

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
            // using simple foreach

            //var result = SelectAll();
            //var list = new List<ProductBase>();
            //foreach (var item in result)
            //{
            //    if (item.Category == category)
            //    {
            //        list.Add(new Computer(item.Id, item.Name, item.Price, item.Category));
            //    }
            //}
            //return list;


            //using lambda expression
            var result = SelectAll();
            return result.FindAll(p =>p.Category == category);
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

        public List<ProductBaseDTO> GetPartOfProductDTO()
        {
            var resultAll = Data.ProductList;

            var list = new List<ProductBaseDTO>();

            for (int i = 0; i < resultAll.Count; i++)
            {
                // use ternary operator
                // int x = 10;
                // int y = 5;
                //var result = x > y ? "x is greater than y" : "x is less than y";

               // use ternary operator
                var id = resultAll[i].Id.ToString();
                string name = resultAll[i].Name.Length > 2 ? resultAll[i].Name.Substring(0, 3).ToUpper() : resultAll[i].Name.Substring(0, 2).ToUpper() + " ";
                string category = resultAll[i].Category.Length > 3 ? resultAll[i].Category.Substring(0, 4).ToUpper() : resultAll[i].Category.Substring(0, 4).ToUpper();
                decimal price = resultAll[i].Price;
                string idnamecategory = id + name + category;


                var productBaseDTO = new ProductBaseDTO()
                {
                    IdNameCategory = idnamecategory,
                    Price = price,
                };
                list.Add(productBaseDTO);
            }
            return list;
        }

       

    }
}
