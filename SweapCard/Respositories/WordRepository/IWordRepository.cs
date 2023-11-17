using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordCounterDtos;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.Respositories.WordRepository
{
    public interface IWordRepository
    {
        Task<List<ResultWordDto>> GetAllWord(int id);
        void CreatWord(WordWithWordCounterDtos wordWithWordCounterDtos); 
        void DeleteWord(int id);
        void CreatWordChatGPT(WordWithWordCounterDtos wordWithWordCounterDtos); 
        void UpdateWord(UpdateWordDtos wordDto); 
        Task<GetByWordIdDto> GetWordId(int id);
        Task<List<ResultWordWithUserDto>> GetAllWordWithUser();
        void UpdateWordshowcounter(int id);  

    }
}
