using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRepository.Models
{
    public class SortByPrice :Comparer<ProductBase>
    {
        public object Price { get; private set; }

        public override int Compare(ProductBase x, ProductBase y)
        {
            return (x.Price).CompareTo(y.Price);
        }
    }
}
