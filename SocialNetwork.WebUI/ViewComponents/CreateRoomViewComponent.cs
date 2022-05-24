using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
using SocialNetwork.WebUI.Models;

namespace SocialNetwork.WebUI.ViewComponents
{
    public class CreateRoomViewComponent : ViewComponent
    {
        public CreateRoomViewComponent(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        private UserManager<CustomIdentityUser> _userManager { get; set; }

        public ViewViewComponentResult Invoke()
        {
            var user = UserHelper.CurrentUser;
            var users = _userManager.Users.Where(u => u.Id != user.Id).ToList();
            return View(new CreateRoomViewModel()
            {
                IdentityUsers = users
            });
        }
    }
}