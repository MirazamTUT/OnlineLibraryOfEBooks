using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;

namespace OnlineLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddUserAsync(UserRequestDTO userRequestDTO)
        {
            try
            {
                var resultId = await _userService.AddUserAsync(userRequestDTO);
                _logger.LogInformation("Added User.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was adding changes.");
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByIdAsync(int id)
        {
            try
            {
                var userResponseDTO = await _userService.GetUserByIdAsync(id);
                _logger.LogInformation("User was found.");
                return userResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            try
            {
                var allUsersResponseDTO = await _userService.GetAllUsersAsync();
                _logger.LogInformation("All Users were found.");
                return allUsersResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving all Users from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteUserAsync(UserRequestDTO userRequestDTO)
        {
            try
            {
                var resultId = await _userService.DeleteUserAsync(userRequestDTO);
                _logger.LogInformation("Deleted User.");
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
