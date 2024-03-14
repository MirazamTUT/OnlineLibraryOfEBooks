namespace OnlineLibrary.DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }


        public UsersLibrary UserLibrary { get; set; }
    }
}
