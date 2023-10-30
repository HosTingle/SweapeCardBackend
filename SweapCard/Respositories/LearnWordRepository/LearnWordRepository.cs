using Dapper;
using RealEstate_Dapper.Dtos.UserDtos;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.LearnWordDtos;
using SweapCard.Dtos.UserDtos;

namespace SweapCard.Respositories.LearnWordRepository
{
    public class LearnWordRepository : ILearnWordRepository
    {
        private readonly Context _context;

        public LearnWordRepository(Context context)
        {
            _context = context;
        }

        public async void CreatLearnWord(CreatLearnWordDto creatLearnWordDto)
        {
            string query = "insert into LearnWord (LearnWordFirst,LearnWordSecond,LearnWordSentence,UserId) values (@learnWordFirst,@learnWordSecond,@learnWordSentence,@userId)";
            var paramaters = new DynamicParameters();
            paramaters.Add("learnWordFirst", creatLearnWordDto.LearnWordFirst);
            paramaters.Add("learnWordSecond", creatLearnWordDto.LearnWordSecond);
            paramaters.Add("learnWordSentence", creatLearnWordDto.LearnWordSentence);
            paramaters.Add("userId", creatLearnWordDto.UserId);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteLearnWord(int id)
        {
            string query = "Delete From LearnWord Where LearnWordId=@learnWordId";
            var parameters = new DynamicParameters(query); 
            parameters.Add("@learnWordId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLearnWordDto>> GetAllLearnWord()
        {
            string query = "Select * From LearnWord";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultLearnWordDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdLearnWordDto> GetLearnWordId(int id)
        {
            string query = "Select * From LearnWord Where LearnWordId=@learnWordId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@learnWordId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdLearnWordDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateLearnWord(UpdateLearnWordDto updateLearnWordDto)
        {
            string query = "Update LearnWord Set LearnWordFirst=@learnWordFirst,LearnWordSecond=@learnWordSecond,LearnWordSentence=@learnWordSentence,UserId=@userId where LearnWordId=@learnWordId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@learnWordId", updateLearnWordDto.LearnWordId);
            paramaters.Add("@learnWordFirst", updateLearnWordDto.LearnWordFirst);
            paramaters.Add("@learnWordSecond", updateLearnWordDto.LearnWordSecond);
            paramaters.Add("@learnWordSentence", updateLearnWordDto.LearnWordSentence);
            paramaters.Add("@userId", updateLearnWordDto.UserId);

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
