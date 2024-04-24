using BE_MusicStreaming.Models;

namespace BE_MusicStreaming.Data
{
    public class UserData
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, Username = "Johnny Dough", Bio = "I like groovy beats.", Uid = "-NwC_r-_0kdGvf7zTA09" },
            new User { Id = 2, Username = "Janet Smithy", Bio = "First lady of Juicy Couture.", Uid = "-NwC_t92250bx6_IMTc6" },
        };
    }
}
