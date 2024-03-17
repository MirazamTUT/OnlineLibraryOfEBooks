using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;

namespace OnlineLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersLibraryController : ControllerBase
    {
        private IUsersLibraryService _usersLibraryService;
        private ILogger<UsersLibraryController> _logger;

        public UsersLibraryController(IUsersLibraryService usersLibraryService, ILogger<UsersLibraryController> logger)
        {
            _usersLibraryService = usersLibraryService;
            _logger = logger;
        }

        public async Task<ActionResult<List<UsersLibraryResponseDTO>>> GetAllUsersLibrariesAsync()
        {
            try
            {
                var allUsersLibrariesResponseDTO = await _usersLibraryService.GetAllUsersLibrariesAsync();
                _logger.LogInformation("All Users' Libraries were found.");
                return allUsersLibrariesResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving Users' Libraries from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<ActionResult<UsersLibraryResponseDTO>> GetUserLibraryByIdAsync(int id)
        {
            try
            {
                var usersLibraryResponseDTO = await _usersLibraryService.GetUserLibraryByIdAsync(id);
                _logger.LogInformation("User's Library was found.");
                return usersLibraryResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User's Library from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }
    }
}
