namespace Shared.SeedWord
{
    public class RequestParameters : PagingRequestParameters
    {
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
    }
}