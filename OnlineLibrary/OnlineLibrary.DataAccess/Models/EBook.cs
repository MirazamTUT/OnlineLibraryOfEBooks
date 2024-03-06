using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.DataAccess.Models
{
    public class EBook
    {
        [Key]
        public int EBookId { get; set; }

        public int MainLibraryId { get; set; }

        public int EBookRatingStars { get; set; }

        public EBookMetaData MetaData { get; set; }

        public EBookFile EBookFile { get; set; }


        public MainLibrary MainLibrary { get; set; }

        public List<UsersLibrary> UsersLibraries { get; set; }
    }


    public class EBookFile
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public long Size { get; set; }
    }

    public class EBookMetaData
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }
    }
}
