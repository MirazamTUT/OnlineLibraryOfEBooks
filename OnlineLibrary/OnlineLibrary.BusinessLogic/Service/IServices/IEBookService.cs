using Microsoft.AspNetCore.Http;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;

namespace OnlineLibrary.BusinessLogic.Service.IServices
{
    public interface IEBookService
    {
        public Task<int> UploadEBookAsync(EBookRequestDTO requestDTO, IFormFile formFile);

        public Task<Stream> GetEBookFileByIdAsync(int id);

        public Task<List<EBookResponseDTO>> GetAllEBooksAsync();

        public Task<int> UpdateEBookAsync(EBookRequestDTO requestDTO, IFormFile? formFile, int? id);

        public Task<int> DeleteEBookAsync(int id);
    }
}
