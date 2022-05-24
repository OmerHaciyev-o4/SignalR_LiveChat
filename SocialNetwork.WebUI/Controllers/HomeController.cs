using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.WebUI.Entities;
using SocialNetwork.WebUI.Helpers;
using SocialNetwork.WebUI.Models;
using System.Security.Claims;

namespace SocialNetwork.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private UserManager<CustomIdentityUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private CustomeIdentityDbContext _context;

        public HomeController(UserManager<CustomIdentityUser> userManager, IHttpContextAccessor httpContextAccessor, CustomeIdentityDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            UserHelper.CurrentUser = user;  
            ViewBag.User = user;
            var users = _userManager.Users.Where(u=>u.Id!=user.Id).ToList();
            foreach (var item in users)
            {
                var onlineUser = UserHelper.ActiveUsers.FirstOrDefault(u => u.Id == item.Id);
                if(onlineUser != null)
                {
                    item.IsOnline = true;
                }
            }
            var model = new HomeUserViewModel
            {
                AllUsers = users,
                ActiveUsers = UserHelper.ActiveUsers
            };
            return View(model);
        }

        public async Task<IActionResult> FindCurrentUser(string id)
        {
            UserHelper.ReceiverUser = _userManager.Users.FirstOrDefault(u=>u.Id==id);

            return RedirectToAction("MessageChat");
        }
        
        public IActionResult MessageChat()
        {
            var model = new ChatModel
            {
                ReceiverUser = UserHelper.ReceiverUser,
                SenderUser = UserHelper.CurrentUser
            };
            //return View(model);
            return View();
        }

        //public async Task<IActionResult> CreateRoom()
        //{




        //}

        public async Task<IActionResult> GetAllActiveUsers()
        {
            return Ok(UserHelper.ActiveUsers.DistinctBy(u=>u.Id));
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = _userManager.Users.Where(u => u.Id != user.Id).ToList();
            foreach (var item in users)
            {
                var onlineUser = UserHelper.ActiveUsers.FirstOrDefault(u => u.Id == item.Id);
                if (onlineUser != null)
                {
                    item.IsOnline = true;
                }
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> SelectedUsers(List<string> selectedUsersList)
        {
            List<CustomIdentityUser> users = new List<CustomIdentityUser>();

            foreach (var user in selectedUsersList)
            {
                foreach (var identityUser in _userManager.Users)
                {
                    if (identityUser.Id == user)
                    {
                        users.Add(identityUser);
                        break;
                    }
                }
            }

            UserHelper.SelectedUsers = users;

            return Ok();
        }
    }
}
