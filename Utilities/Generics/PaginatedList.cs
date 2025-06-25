using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Utilities.Generics
{
    public class PaginatedList<T> where T : class
    {
        public IEnumerable<T> Items { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public int Start => CurrentPage - 2 < 1 ? 1 : CurrentPage - 2;
        public int End => CurrentPage + 2 > TotalPages ? TotalPages : CurrentPage + 2;

        private PaginatedList(IEnumerable<T> items, int count, int currentPage, int pageSize)
        {
            Items = items;
            TotalCount = count;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int page, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(items, count, page, pageSize);
        }
    }
}
