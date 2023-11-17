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

        public async Task<int> CreateScore()
        {
            string query = "INSERT INTO Score (Score) VALUES (@score); SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var parameters = new DynamicParameters();
            parameters.Add("score", 0);

            using (var connection = _context.CreatConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<int?>(query, parameters);
                int? scoreId = result;

                if (scoreId.HasValue)
                {
                    return scoreId.Value;
                }
                else
                {
                    // İşlem başarısız olduysa burada bir hata işleyebilirsiniz.
                    throw new Exception("Score eklenemedi.");
                }
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
