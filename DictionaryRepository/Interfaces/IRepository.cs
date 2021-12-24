using DictionaryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository.Interfaces
{
    public interface IRepository
    {
        Dictionary<int, Product> SelectAll();
        Product Select(int id);

        void Insert(Product product);

        void Update(Product product);
        void Delete(int id);

    }
}
