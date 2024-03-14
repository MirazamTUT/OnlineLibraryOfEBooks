using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.BusinessLogic.Service.Services
{
    public class UsersLibraryService : IUsersLibraryService
    {
        private  readonly IUsersLibraryRepository _usersLibraryRepository;
        private readonly ILogger<UsersLibraryService> _logger;
        private readonly IMapper _mapper;

        public UsersLibraryService(IUsersLibraryRepository usersLibraryRepository, ILogger<UsersLibraryService> logger, IMapper mapper)
        {
            _usersLibraryRepository = usersLibraryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<UsersLibraryResponseDTO>> GetAllUsersLibrariesAsync()
        {
            try
            {
                var allUsersLibraries = _mapper.Map<List<UsersLibraryResponseDTO>>
                    (await _usersLibraryRepository.GetAllUsersLibrariesWithoutFileAsync());
                _logger.LogInformation("All Users' Libraries were found.");
                return allUsersLibraries;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving Users' Libraries from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<UsersLibraryResponseDTO> GetUserLibraryByIdAsync(int id)
        {
            try
            {
                var usersLibrary = _mapper.Map<UsersLibraryResponseDTO>
                    (await _usersLibraryRepository.GetUsersLibraryByIdWithoutFileAsync(id));
                _logger.LogInformation("User's Library was found and returned without file.");
                return usersLibrary;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User's Library from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }
    }
}
