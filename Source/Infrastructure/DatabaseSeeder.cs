using Application.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Tawasal
{

    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        public DatabaseSeeder(UserManager<IdentityUser> _UserManager,
            RoleManager<IdentityRole> _RoleManager,
            AuthenticationStateProvider AuthenticationStateProvider)
        {
            this._RoleManager = _RoleManager;
            this._UserManager = _UserManager;
        }
        public async Task InitializeAsync()
        {
            await AddBasicUserAsync();
        }

        string ADMINISTRATION_ROLE = "Administrators";

        string userEmail = "test@gmail.com";
        string userPass = "1q2w3e4r!Q@W#E$R";
        private async Task AddBasicUserAsync()
        {
            var RoleResult = await _RoleManager.FindByNameAsync(ADMINISTRATION_ROLE);
            if (RoleResult == null)
            {
                await _RoleManager.CreateAsync(new IdentityRole(ADMINISTRATION_ROLE));
            }
            var user = await _UserManager.FindByNameAsync(userEmail);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _UserManager.CreateAsync(user, userPass);
                var UserResult = await _UserManager.IsInRoleAsync(user, ADMINISTRATION_ROLE);
                if (!UserResult)
                {
                    await _UserManager.AddToRoleAsync(user, ADMINISTRATION_ROLE);
                }
            }

        }
    }
}
