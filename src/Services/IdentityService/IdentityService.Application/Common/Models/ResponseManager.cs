namespace IdentityService.Application.Common.Models
{
    public class ResponseManager
    {
        public bool IsSuccess { get; set; }
        public dynamic? Message { get; set; }
        public dynamic? Data { get; set; }
        public IEnumerable<dynamic>? Errors { get; set; }
    }
}