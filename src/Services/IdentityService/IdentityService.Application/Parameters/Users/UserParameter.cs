using IdentityService.Application.Common.Interfaces;
using Shared.SeedWord;

namespace IdentityService.Application.Parameters.Users;

public class UserParameter : RequestParameters, IPaginationParameters
{
    public bool? IsDeleted { get; set; }
}