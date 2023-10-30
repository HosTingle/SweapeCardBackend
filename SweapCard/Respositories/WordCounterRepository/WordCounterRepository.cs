using Dapper;
using RealEstate_Dapper.Dtos.UserDtos;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordCounterDtos;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.Respositories.WordCounterRepository
{
    public class WordCounterRepository : IWordCounterRepository
    {
        private readonly Context _context;

        public WordCounterRepository(Context context)
        {
            _context = context;
        }

        public async void  CreatWordCounter(CreatWordCounterDto wordCounterDto)
        {
            string query = "insert into WordCounter (WordCounter,LearnWordCounter) values (@wordCounter,@learnWordCounter)";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordCounter", wordCounterDto.WordCounter);
            paramaters.Add("learnWordCounter", wordCounterDto.LearnWordCounter);
      

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteWordCounter(int id)
        {
            string query = "Delete From WordCounter Where WordCounterId=@wordCounterId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordCounterId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWordCounterDto>> GetAllWordCounter()
        {
            string query = "Select * From WordCounter";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultWordCounterDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByWordCounterIdDto> GetWordCounterId(int id)
        {
            string query = "Select * From WordCounter Where WordCounterId=@wordCounterId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordCounterId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByWordCounterIdDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWordCounter(UpdateWordCounterDto wordCounterDto)
        {
            string query = "Update WordCounter Set WordCounter=@wordCounter,LearnWordCounter=@learnWordCounter where WordCounterId=@wordCounterId";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordCounterId", wordCounterDto.WordCounterId);
            paramaters.Add("wordCounter", wordCounterDto.WordCounter);
            paramaters.Add("learnWordCounter", wordCounterDto.LearnWordCounter);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
