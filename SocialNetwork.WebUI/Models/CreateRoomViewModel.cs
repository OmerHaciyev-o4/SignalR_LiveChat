using SocialNetwork.WebUI.Entities;

namespace SocialNetwork.WebUI.Models
{
    public class CreateRoomViewModel
    {
        public Room UseRoom { get; set; }
        public List<CustomIdentityUser> IdentityUsers { get; set; }
        public IFormFile File { get; set; }
    }
}