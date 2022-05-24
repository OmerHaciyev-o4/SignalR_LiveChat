using SocialNetwork.WebUI.Entities;

namespace SocialNetwork.WebUI.Models
{
    public class HomeUserViewModel
    {
        public List<CustomIdentityUser> AllUsers { get; set; }
        public List<CustomIdentityUser> ActiveUsers { get; set; }
    }
}
