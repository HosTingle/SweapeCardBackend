using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;

namespace RealEstate_Dapper.Respositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<ResultUserDto>> GetAllUser();
        void CreatUser(CreatUserDto userDto);
        void DeleteUser(int id);
        void UpdateUser(UpdateUserDto userDto);
        Task<GetByIdUserDto> GetUserId(int id);
        Task<List<ResultUserWithOtherDto>> GetAllUserWithOther(); 
    }
}
