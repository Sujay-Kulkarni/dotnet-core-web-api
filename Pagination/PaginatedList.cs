using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; set; }
        public PaginatedList(List<T> data, int cout, int? pageindex, int pagesize)
        {
            PageIndex = (int)(pageindex == 0 ? 1 : pageindex);
            PageSize = pagesize == 0 ? 5 : pagesize;
            TotalPages = (int)Math.Ceiling(cout / (double)PageSize);

            this.AddRange(data);
        }

        public bool HasPreviousPage { get { return PageIndex > 1; } }

        public bool HasNextPage { get { return PageIndex < TotalPages; } }

        public static PaginatedList<T> Create(IQueryable<T> source, int? pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
