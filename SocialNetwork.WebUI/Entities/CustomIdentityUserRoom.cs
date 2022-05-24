namespace SocialNetwork.WebUI.Entities
{
    public class CustomIdentityUserRoom
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }

        public CustomIdentityUser User { get; set; }
        public Room Room { get; set; }
    }
}