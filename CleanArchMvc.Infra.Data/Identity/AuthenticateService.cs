using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, false);
            }

            return result.Succeeded;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
