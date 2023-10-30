using SweapCard.Dtos.LearnWordDtos;
using SweapCard.Dtos.ScoreDtos;

namespace SweapCard.Respositories.ScoreRepository
{
    public interface IScoreRepository
    {
        Task<List<ResultScoreDto>> GetAllScore();
        void CreatScore();
        void DeleteScore(int id);  
        void UpdateScore(ResultScoreDto resultScoreDto);
        Task<ResultScoreDto> GetScoreId(int id); 
    }
}
