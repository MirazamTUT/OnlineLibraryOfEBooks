using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;

namespace OnlineLibrary.BusinessLogic.Service.IServices
{
    public interface IUsersLibraryService
    {
        public Task<int> AddUsersLibraryAsync(int userId);

        public Task<UsersLibraryResponseDTO> GetUserLibraryByIdAsync(int id);

        public Task<List<UsersLibraryResponseDTO>> GetAllUsersLibrariesAsync();

        public Task<int> DeleteUsersLibraryAsync(int id);
    }
}
