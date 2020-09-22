using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuotingSystem.Models
{
    public class PaginateList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginateList(List<T> Items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            this.AddRange(Items);
        }
        public bool HasPreviousPage { get => PageIndex > 1; }
        public bool HasNextPage { get => PageIndex < TotalPages; }

        public static PaginateList<T> Create (IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginateList<T>(items, count, pageIndex, pageSize);
        }
    }
}