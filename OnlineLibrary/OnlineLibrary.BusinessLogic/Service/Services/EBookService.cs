using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;
using OnlineLibrary.DataAccess.Models;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.BusinessLogic.Service.Services
{
    public class EBookService : IEBookService
    {
        private readonly IEBookRepository _eBookRepository;
        private readonly ILogger<EBookService> _logger;

        public EBookService(IEBookRepository eBookRepository, ILogger<EBookService> logger)
        {
            _eBookRepository = eBookRepository;
            _logger = logger;
        }

        public async Task<int> UploadEBookAsync(EBookRequestDTO requestDTO, IFormFile formFile)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await formFile.CopyToAsync(memoryStream);
                var fileContent = memoryStream.ToArray();

                var eBook = new EBook()
                {
                    Title = requestDTO.Title,
                    Author = requestDTO.Author,
                    Description = requestDTO.Description,
                    Tags = requestDTO.Tags,
                    ContentType = formFile.ContentType,
                    Content = fileContent,
                    EBookRatingStars = requestDTO.EBookRatingStars
                };

                int eBookId = await _eBookRepository.AddEBookAsync(eBook);
                _logger.LogInformation("Finished uploading E-Book to db.");
                return eBookId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was uploading changes.");
            }
        }

        public async Task<Stream> GetEBookFileByIdAsync(int id)
        {
            try
            {
                var fileEntity = await _eBookRepository.GetEBookByIdAsync(id);
                if (fileEntity == null)
                    return null;

                var fileStream = new MemoryStream(fileEntity.Content);
                _logger.LogInformation("Founded E-Book.");
                return fileStream;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }

        public Task<List<EBookResponseDTO>> GetAllEBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEBookAsync(EBookRequestDTO requestDTO, IFormFile? formFile, int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteEBookAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
