using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.Respositories.WordRepository
{
    public interface IWordRepository
    {
        Task<List<ResultWordDto>> GetAllWord();
        void CreatWord(CreatWordDto wordDto); 
        void DeleteWord(int id); 
        void UpdateWord(UpdateWordDtos wordDto); 
        Task<GetByWordIdDto> GetWordId(int id);
        Task<List<ResultWordWithUserDto>> GetAllWordWithUser();
    }
}
