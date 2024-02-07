namespace IdentityService.Application.Common.Interfaces;

public interface IPaginationParameters
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}