using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.LearnWordDtos;
using SweapCard.Dtos.UserDtos;

namespace SweapCard.Respositories.LearnWordRepository
{
    public interface ILearnWordRepository
    {
        Task<List<ResultLearnWordDto>> GetAllLearnWord(); 
        void CreatLearnWord(CreatLearnWordDto creatLearnWordDto); 
        void DeleteLearnWord(int id); 
        void UpdateLearnWord(UpdateLearnWordDto updateLearnWordDto);  
        Task<GetByIdLearnWordDto> GetLearnWordId(int id); 
    }
}
