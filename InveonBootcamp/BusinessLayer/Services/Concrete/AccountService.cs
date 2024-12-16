using BusinessLayer.Services.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<UserApp> _signInManager;

        public AccountService(SignInManager<UserApp> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
