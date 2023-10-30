using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordCounterDtos;

namespace SweapCard.Respositories.WordCounterRepository
{
    public interface IWordCounterRepository
    {
        Task<List<ResultWordCounterDto>> GetAllWordCounter(); 
        void CreatWordCounter(CreatWordCounterDto wordCounterDto);
        void DeleteWordCounter(int id); 
        void UpdateWordCounter(UpdateWordCounterDto wordCounterDto);  
        Task<GetByWordCounterIdDto> GetWordCounterId(int id); 
      
    }
}
