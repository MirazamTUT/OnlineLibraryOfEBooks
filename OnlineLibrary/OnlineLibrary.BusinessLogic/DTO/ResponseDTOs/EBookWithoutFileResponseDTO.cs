using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.BusinessLogic.DTO.ResponseDTOs
{
    public class EBookWithoutFileResponseDTO : EBook
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public int EBookRatingStars { get; set; }
    }
}
