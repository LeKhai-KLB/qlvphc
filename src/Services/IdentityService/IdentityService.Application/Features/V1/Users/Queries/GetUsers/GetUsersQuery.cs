using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Application.Parameters.Users;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<PagedResponse<IEnumerable<UserDto>>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public string? HoTen { get; set; }
    public bool? IsDeleted { get; set; }

    public GetUsersQuery(UserParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        HoTen = request.HoTen;
        IsDeleted = request.IsDeleted;
    }
}