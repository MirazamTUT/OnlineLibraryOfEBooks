using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;

namespace OnlineLibrary.BusinessLogic.Service.IServices
{
    public interface IUserService
    {
        public Task<int> AddUserAsync(UserRequestDTO userRequestDTO);

        public Task<UserResponseDTO> GetUserByIdAsync(int id);

        public Task<List<UserResponseDTO>> GetAllUsersAsync();

        public Task<int> UpdateUserAsync(UserRequestDTO userRequestDTO, int? id);

        public Task<int> UpdateUserAsync(int id);
    }
}
