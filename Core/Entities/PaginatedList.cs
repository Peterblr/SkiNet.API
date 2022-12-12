using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> source, int pageIndex, int pageSize)
        {
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            AddRange(items);
        }
    }
}
