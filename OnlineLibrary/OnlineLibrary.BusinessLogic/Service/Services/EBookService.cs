using AutoMapper;
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
        private readonly IMapper _mapper;

        public EBookService(IEBookRepository eBookRepository, ILogger<EBookService> logger, IMapper mapper)
        {
            _eBookRepository = eBookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> UploadEBookAsync(EBookRequestDTO requestDTO)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await requestDTO.formFile.CopyToAsync(memoryStream);
                var fileContent = memoryStream.ToArray();

                var eBook = _mapper.Map<EBook>(requestDTO);
                eBook.ContentType = requestDTO.formFile.ContentType;
                eBook.Content = fileContent;

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
                var fileEntity = await _eBookRepository
                    .GetEBookByIdAsync(id) ?? throw new Exception("E-Book was not found.");

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

        public async Task<EBookResponseDTO> GetEBookByIdAsync(int id)
        {
            try
            {
                var eBookResponseDTO = _mapper.Map<EBookResponseDTO>(await _eBookRepository.GetEBookByIdAsync(id));
                _logger.LogInformation("Founded E-Book.");
                return eBookResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }

        public async Task<List<EBookResponseDTO>> GetAllEBooksAsync()
        {
            try
            {
                var allEBooks = _mapper.Map<List<EBookResponseDTO>>(await _eBookRepository.GetAllEBooksAsync());
                _logger.LogInformation("All E-Books were found.");
                return allEBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving files: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving files.");
            }
        }

        public async Task<List<EBookWithoutFileResponseDTO>> GetAllEBooksWithoutFileAsync()
        {
            try
            {
                var allEBooksWithoutFile = _mapper.Map<List<EBookWithoutFileResponseDTO>>
                    (await _eBookRepository.GetAllEBooksWithoutFileAsync());
                _logger.LogInformation("All E-Books were found and returned without files.");
                return allEBooksWithoutFile;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving files: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving files.");
            }
        }

        public async Task<int> UpdateEBookAsync(EBookRequestDTO requestDTO)
        {
            try
            {
                var eBookForUpdate = await _eBookRepository.GetEBookByTitleAndAuthorAsync(requestDTO.Title, requestDTO.Author);
                eBookForUpdate.Title = requestDTO.Title;
                eBookForUpdate.Author = requestDTO.Author;
                eBookForUpdate.Description = requestDTO.Description;
                eBookForUpdate.Tags = requestDTO.Tags;
                eBookForUpdate.EBookRatingStars = requestDTO.EBookRatingStars;

                if (requestDTO.formFile is not null)
                {
                    using var memoryStream = new MemoryStream();
                    await requestDTO.formFile.CopyToAsync(memoryStream);
                    var fileContent = memoryStream.ToArray();

                    eBookForUpdate.ContentType = requestDTO.formFile.ContentType;
                    eBookForUpdate.Content = fileContent;
                }

                var resultId = await _eBookRepository.UpdateEBookAsync(eBookForUpdate);
                _logger.LogInformation("E-Book was updated.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }

        public async Task<int> DeleteEBookByIdAsync(int id)
        {
            try
            {
                var eBookForDelete = await _eBookRepository.GetEBookByIdAsync(id);
                var resultId = await _eBookRepository.DeleteEBookAsync(eBookForDelete);
                _logger.LogInformation("Deleted E-Book from DB.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
