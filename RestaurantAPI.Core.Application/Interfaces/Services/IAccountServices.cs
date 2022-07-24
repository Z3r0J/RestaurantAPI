using RestaurantAPI.Core.Application.DTOS.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IAccountServices
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task LogOutAsync();
        Task<List<AccountResponse>> GetUsersAsync();
    }
}