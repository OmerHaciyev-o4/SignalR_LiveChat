using SocialNetwork.WebUI.Entities;

namespace SocialNetwork.WebUI.Models
{
    public class ChatModel
    {
        public CustomIdentityUser ReceiverUser { get; set; }
        public CustomIdentityUser SenderUser { get; set; }
    }
}
