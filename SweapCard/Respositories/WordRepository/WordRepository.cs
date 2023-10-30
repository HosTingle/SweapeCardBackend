using Dapper;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;

namespace SweapCard.Respositories.WordRepository
{
    public class WordRepository : IWordRepository
    {
        private readonly Context _context;
        public WordRepository(Context context)
        {
            _context = context;
        }

        public async void CreatWord(CreatWordDto wordDto)
        {
            string query = "insert into Words (UserId,FirstWord,SecondWord,Sentence,Image,DescriptionWord,ShowCounter,LanguageId) values (@userId,@firstWord,@secondWord,@sentence,@image,@descriptionWord,@showCounter,@languageId)";
            var paramaters = new DynamicParameters();
            paramaters.Add("userId", wordDto.UserId);
            paramaters.Add("firstWord", wordDto.FirstWord);
            paramaters.Add("secondWord", wordDto.SecondWord);
            paramaters.Add("sentence", wordDto.Sentence);
            paramaters.Add("image", wordDto.Image);
            paramaters.Add("descriptionWord", wordDto.DescriptionWord);
            paramaters.Add("showCounter", wordDto.ShowCounter);
            paramaters.Add("languageId", wordDto.LanguageId);

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteWord(int id)
        {
            string query = "Delete From Words Where WordId=@wordId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWordDto>> GetAllWord()
        {
            string query = "Select * From Words Order by WordId asc";
            using(var connection= _context.CreatConnection())
            {
                var values= await connection.QueryAsync<ResultWordDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultWordWithUserDto>> GetAllWordWithUser()
        {
            string query = "Select WordId,Username,FirstWord,SecondWord,Sentence,Image,DescriptionWord,ShowCounter,LanguageId From Words inner join Users on Words.UserId=Users.UserId";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultWordWithUserDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByWordIdDto> GetWordId(int id)
        {
            string query = "Select * From Words Where WordId=@wordId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByWordIdDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWord(UpdateWordDtos wordDto)
        {
            string query = "Update Words Set UserId=@userId,FirstWord=@firstWord,SecondWord=@secondWord,Sentence=@sentence,Image=@image,DescriptionWord=@descriptionWord,ShowCounter=@showCounter,LanguageId=@languageId where WordId=@wordId";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordId", wordDto.WordId);
            paramaters.Add("userId", wordDto.UserId);
            paramaters.Add("firstWord", wordDto.FirstWord);
            paramaters.Add("secondWord", wordDto.SecondWord);
            paramaters.Add("Sentence", wordDto.Sentence);
            paramaters.Add("image", wordDto.Image);
            paramaters.Add("descriptionWord", wordDto.DescriptionWord);
            paramaters.Add("showCounter", wordDto.ShowCounter);
            paramaters.Add("languageId", wordDto.LanguageId);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
