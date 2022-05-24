using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WebUI.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomImageUrl { get; set; }

        public virtual ICollection<MessageCloud> Clouds { get; set; }
        public virtual ICollection<CustomIdentityUserRoom> CustomIdentityUserRooms { get; set; }

        public Room()
        {
            Clouds = new List<MessageCloud>();
            CustomIdentityUserRooms = new HashSet<CustomIdentityUserRoom>();
        }
    }
}