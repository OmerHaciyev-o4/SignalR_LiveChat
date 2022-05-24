namespace SocialNetwork.WebUI.Entities
{
    public class MessageCloud
    {
        public int Id { get; set; }
        public Message Message { get; set; }

        public int FriendId { get; set; }
        public virtual CustomIdentityUser CustomIdentityFriend { get; set; }
    }
}