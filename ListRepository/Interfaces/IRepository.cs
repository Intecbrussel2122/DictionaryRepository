using ListRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Interfaces
{
    public interface IRepository
    {
        List<ProductBase> SelectAll();
        void Insert(ProductBase product);
        void Update(ProductBase product);
        void Delete(int id);
        ProductBase SelectSingle(int id);
        bool Find(int find);
    }
}
