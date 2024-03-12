namespace OnlineLibrary.BusinessLogic.DTO.ResponseDTOs
{
    public class EBookResponseDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public int EBookRatingStars { get; set; }
    }
}
