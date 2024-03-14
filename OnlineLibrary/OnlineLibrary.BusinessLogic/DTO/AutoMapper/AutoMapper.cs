using AutoMapper;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.BusinessLogic.DTO.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<EBookRequestDTO, EBook>();
            CreateMap<EBook, EBookWithoutFileResponseDTO>();
            CreateMap<EBook, EBookResponseDTO>();

            CreateMap<UserRequestDTO, User>();
            CreateMap<User, UserResponseDTO>();

            CreateMap<UsersLibraryResponseDTO, UsersLibrary>();
        }
    }
}
