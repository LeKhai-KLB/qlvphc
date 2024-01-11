using System.Text.Json.Serialization;

namespace Shared.SeedWord
{
    public class PagedResponse<T> : ApiResult<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int FirstRowOnPage => TotalItems > 0 ? (CurrentPage - 1) * PageSize + 1 : 0;

        [JsonConstructor]
        public PagedResponse(T data, int currentPage, int totalPages, int pageSize, long totalItems) : base(true, data)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
        public PagedResponse(T data, string message) : base(true, data, message)
        {

        }
    }
}
