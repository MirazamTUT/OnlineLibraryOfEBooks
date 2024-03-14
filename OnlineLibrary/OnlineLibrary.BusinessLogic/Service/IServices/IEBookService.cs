using Microsoft.AspNetCore.Http;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;

namespace OnlineLibrary.BusinessLogic.Service.IServices
{
    public interface IEBookService
    {
        public Task<int> UploadEBookAsync(EBookRequestDTO requestDTO);

        public Task<Stream> GetEBookFileByIdAsync(int id);

        public Task<List<EBookResponseDTO>> GetAllEBooksAsync();

        public Task<List<EBookWithoutFileResponseDTO>> GetAllEBooksWithoutFileAsync();

        public Task<int> UpdateEBookAsync(EBookRequestDTO requestDTO);

        public Task<int> DeleteEBookByIdAsync(int id);
    }
}
