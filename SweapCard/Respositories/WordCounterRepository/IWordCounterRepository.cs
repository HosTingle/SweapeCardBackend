using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordCounterDtos;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.Respositories.WordCounterRepository
{
    public interface IWordCounterRepository
    {
        Task<List<ResultWordCounterDto>> GetAllWordCounter(); 
        Task<int> CreatWordCounter();
        void DeleteWordCounter(int id); 
        void UpdateWordCounter(UpdateWordCounterDto updateWordCounterDto);  
        Task<UpdateWordCounterDto> GetWordCounterId(int id);
        void OneWordAdd(WordWithWordCounterDtos wordWithWordCounterDtos); 



    }
}
