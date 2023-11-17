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
        public async Task<int> CreatWordCounter()
        {
            string query = "insert into WordCounter (WordCounter,LearnWordCounter) values (@wordCounter,@learnWordCounter); SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordCounter", 0);
            paramaters.Add("learnWordCounter", 0);
            using (var connection = _context.CreatConnection())
            {
                int? result = await connection.QueryFirstOrDefaultAsync<int?>(query, paramaters);
                int? wordCounterId = result;
               
                if (wordCounterId.HasValue)
                {
                    return wordCounterId.Value;
                }
                else
                {
                    // İşlem başarısız olduysa burada bir hata işleyebilirsiniz.
                    throw new Exception("WordCounter eklenemedi.");
                }
            }
        }
        public async Task<UpdateWordCounterDto> GetWordCounterId(int id)
        {
            string query = "Select * From WordCounter Where WordCounterId=@wordCounterId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordCounterId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UpdateWordCounterDto>(query, parameters);
                return values;
            }
        }
        public async void OneWordAdd(WordWithWordCounterDtos wordWithWordCounterDtos)
        {
            
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

       

        public async void UpdateWordCounter(UpdateWordCounterDto updateWordCounterDto)
        {
            string query = "Update WordCounter Set WordCounter=@wordCounter,LearnWordCounter=@learnWordCounter where WordCounterId=@wordCounterId";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordCounterId", updateWordCounterDto.WordCounterId);
            paramaters.Add("wordCounter", updateWordCounterDto.WordCounter);
            paramaters.Add("learnWordCounter", updateWordCounterDto.LearnWordCounter);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
