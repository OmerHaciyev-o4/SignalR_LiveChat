using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.WebUI.Entities
{
    public class CustomIdentityUser :IdentityUser
    {
        public string ImageUrl { get; set; }
        public bool IsOnline { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<CustomIdentityUserRoom> CustomIdentityUserRooms { get; set; }

        public CustomIdentityUser()
        {
            Messages = new List<Message>();
            CustomIdentityUserRooms = new HashSet<CustomIdentityUserRoom>();
        }
    }
}