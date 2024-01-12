namespace IdentityService.API.Models
{
    public class ResponseManager
    {
        public bool IsSuccess { get; set; }
        public dynamic? Message { get; set; }
        public IEnumerable<dynamic>? Errors { get; set; }
    }
}