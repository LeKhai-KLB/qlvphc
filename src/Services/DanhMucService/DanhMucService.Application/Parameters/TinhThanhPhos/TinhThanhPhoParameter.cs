using Shared.SeedWord;

namespace DanhMucService.Application.Parameters.TinhThanhPhos
{
    public class TinhThanhPhoParameter : RequestParameters
    {
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}