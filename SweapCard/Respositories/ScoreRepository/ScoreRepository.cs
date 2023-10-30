using Dapper;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.AvatarDtos;
using SweapCard.Dtos.ScoreDtos;

namespace SweapCard.Respositories.ScoreRepository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly Context _context;

        public ScoreRepository(Context context)
        {
            _context = context;
        }

        public async void CreatScore()
        {
            string query = "insert into Score (Score) values (@score)";
            var paramaters = new DynamicParameters();
            paramaters.Add("score", 0);


            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteScore(int id)
        {
            string query = "Delete From Score Where ScoreId=@scoreId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@scoreId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultScoreDto>> GetAllScore()
        {
            string query = "Select * From Score Order By Score Desc";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultScoreDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultScoreDto> GetScoreId(int id)
        {
            string query = "Select * From Score Where ScoreId=@scoreId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@scoreId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultScoreDto>(query, parameters);
                return values;
            }
        }

        public  async void UpdateScore(ResultScoreDto resultScoreDto)
        {
            string query = "Update Score Set Score=@score where ScoreId=@scoreId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@scoreId", resultScoreDto.ScoreId);
            paramaters.Add("@score", resultScoreDto.Score);


            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
