using AspNetCoreCA.Application.DTOs.Account.Requests;
using AspNetCoreCA.Application.DTOs.Account.Responses;
using AspNetCoreCA.Application.Wrappers;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
