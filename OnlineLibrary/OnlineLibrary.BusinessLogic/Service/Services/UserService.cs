using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;
using OnlineLibrary.DataAccess.Models;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.BusinessLogic.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsersLibraryRepository _usersLibraryRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUsersLibraryRepository usersLibraryRepository, ILogger<UserService> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _usersLibraryRepository = usersLibraryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> AddUserAsync(UserRequestDTO userRequestDTO)
        {
            try
            {
                if (await _userRepository.GetUserByUserNameAsync(userRequestDTO.UserName) is not null)
                {
                    var userId = await _userRepository.AddUserAsync(_mapper.Map<User>(userRequestDTO));
                    await _usersLibraryRepository.AddUsersLibraryAsync(new UsersLibrary() { UserId = userId });
                    return userId;
                }
                throw new Exception("Choose enather UserName please.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was adding changes.");
            }
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var user = _mapper.Map<UserResponseDTO>(await _userRepository.GetUserByIdAsync(id));
                _logger.LogInformation("User was found.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            try
            {
                var allUsers = _mapper.Map<List<UserResponseDTO>>(await _userRepository.GetAllUsersAsync());
                _logger.LogInformation("All Users were found.");
                return allUsers;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving all Users from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<int> DeleteUserAsync(UserRequestDTO userRequestDTO)
        {
            try
            {
                var userForDelete = await _userRepository.GetUserByUserNameAsync(userRequestDTO.UserName);
                var usersLibraryForDelete = await _usersLibraryRepository.GetUsersLibraryByIdWithFileAsync(userForDelete.UserLibrary.UsersLibraryId);
                await _usersLibraryRepository.DeleteUsersLibraryAsync(usersLibraryForDelete);
                var resultId = await _userRepository.DeleteUserAsync(userForDelete);
                _logger.LogInformation("User deleted from DB.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
