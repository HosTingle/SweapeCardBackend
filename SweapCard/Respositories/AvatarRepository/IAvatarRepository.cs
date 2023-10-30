using SweapCard.Dtos.AvatarDtos;
using SweapCard.Dtos.LanguageDtos;

namespace SweapCard.Respositories.AvatarRepository
{
    public interface IAvatarRepository
    {
        Task<List<ResultAvatarDto>> GetAllAvatar(); 
        void CreatAvatar(ResultAvatarDto resultAvatarDto);
        void DeleteAvatar(int id); 
        void UpdateAvatar(ResultAvatarDto resultAvatarDto); 
        Task<ResultAvatarDto> GetAvatarId(int id);  
    }
}
