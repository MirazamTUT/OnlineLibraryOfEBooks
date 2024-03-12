using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;

namespace OnlineLibrary.BusinessLogic.Service.Services
{
    public class UsersLibraryService : IUsersLibraryService
    {
        public Task<int> AddUsersLibraryAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUsersLibraryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsersLibraryResponseDTO>> GetAllUsersLibrariesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsersLibraryResponseDTO> GetUserLibraryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
