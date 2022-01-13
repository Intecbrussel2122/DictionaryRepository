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
        List<Computer> SelectAll();
        void Insert(Computer product);
        void Update(Computer product);
        void Delete(int id);
        Computer SelectSingle(int id);
        bool Find(int find);
    }
}
