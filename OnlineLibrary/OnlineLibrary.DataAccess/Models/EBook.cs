namespace OnlineLibrary.DataAccess.Models
{
    public class EBook
    {
        public int EBookId { get; set; }

        public int MainLibraryId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public int EBookRatingStars { get; set; }


        public MainLibrary MainLibrary { get; set; }

        public List<UsersLibrary> UsersLibraries { get; set; }
    }
}
