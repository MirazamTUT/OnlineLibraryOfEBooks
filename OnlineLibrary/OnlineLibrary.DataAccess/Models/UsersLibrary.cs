namespace OnlineLibrary.DataAccess.Models
{
    public class UsersLibrary
    {
        public int UsersLiraryId { get; set; }

        public List<int> EBookId { get; set; }


        public User User { get; set; }

        public List<EBook> EBooks { get; set;}
    }
}
