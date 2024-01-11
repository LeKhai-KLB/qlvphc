using Microsoft.EntityFrameworkCore;

namespace Shared.SeedWord
{
    public class PageList<T> : List<T>
    {
        private MetaData _metaData { get; }

        public PageList(IEnumerable<T> items, long totalItems, int pageNumber, int pageSize)
        {
            _metaData = new MetaData
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
            AddRange(items);
        }

        public MetaData GetMetaData()
        {
            return _metaData;
        }

        public static async Task<PageList<T>> ToPageList(IQueryable<T> source,
           int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }

        
    }
}