using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Models
{
    public class SortByPrice :IComparer<ProductBase>
    {
        public decimal Price { get;}

        public int Compare(ProductBase x, ProductBase y)
        {
            return (x.Price).CompareTo(y.Price);
        }
    }
}
