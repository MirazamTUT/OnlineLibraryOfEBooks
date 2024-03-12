using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;

namespace OnlineLibrary.BusinessLogic.Service.Services
{
    public class UserService : IUserService
    {
        public Task<int> AddUserAsync(UserRequestDTO userRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUserAsync(UserRequestDTO userRequestDTO, int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
