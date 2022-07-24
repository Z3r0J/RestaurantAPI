using RestaurantAPI.Core.Application.DTOS.Account;
using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Identity.Services
{
    public class AccountServices : IAccountServices
    {

        private readonly UserManager<RestaurantUsers> _userManager;
        private readonly SignInManager<RestaurantUsers> _signInManager;


        public AccountServices(UserManager<RestaurantUsers> userManager, SignInManager<RestaurantUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {

            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"You don't have an account with this email {request.Email}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid credential for {request.Email}";
                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Your Account is disable, Contact an Administrator.";
                return response;
            }

            response.Id = user.Id;
            response.FirstName = user.Name;
            response.LastName = user.LastName;
            response.Documents = user.Documents;
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Phone = user.PhoneNumber;

            var RoleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = RoleList.ToList();
            response.IsVerified = user.EmailConfirmed;

            return response;
        }

        public async Task<List<AccountResponse>> GetUsersAsync() {

            List<AccountResponse> accounts = new();

            var response = await _userManager.Users.ToListAsync();

            foreach (RestaurantUsers user in response)
            {
               var roles = await _userManager.GetRolesAsync(user);

                AccountResponse account = new() { 
                Id = user.Id,
                FirstName=user.Name,
                LastName=user.LastName,
                Documents = user.Documents,
                Email = user.Email,
                Roles = roles.ToList(),
                UserName=user.UserName,
                IsVerified = user.EmailConfirmed,
                Phone = user.PhoneNumber
                };

                accounts.Add(account);
            }

            return accounts;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
