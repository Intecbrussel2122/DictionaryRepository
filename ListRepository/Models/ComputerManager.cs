﻿using ListRepository.Database;
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
                    list.Add(new Computer(item.Id, item.Name, item.Price,item.Category));
                }
            }
            return list;
        }
    }
}