using Dapper;
using RealEstate_Dapper.Models.DapperContext;
using RealEstate_Dapper.Respositories.UserRepository;
using SweapCard.ChatGpt;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;
using SweapCard.Respositories.WordCounterRepository;

namespace SweapCard.Respositories.WordRepository
{
    public class WordRepository : IWordRepository
    {
        public HttpClient Http;
        private readonly Context _context;
        private readonly IWordCounterRepository _wordCounterRepository;
        private readonly IUserRepository _userRepository;
        ChatGptWords _chatgptwords;
        
        
        public WordRepository(Context context,IWordCounterRepository wordCounterRepository,IUserRepository userRepository,ChatGptWords chatGptWords)
        {
            _context = context;
            _wordCounterRepository=wordCounterRepository;
            _userRepository=userRepository;
            _chatgptwords=chatGptWords;
        }

        public async void CreatWord(WordWithWordCounterDtos wordWithWordCounterDtos)
        {
            var sasa=_userRepository.GetUserId(wordWithWordCounterDtos.UserId);
            var sa=_wordCounterRepository.GetWordCounterId(sasa.Result.WordCounterId).Result;
            sa.WordCounter = sa.WordCounter + 1;
            _wordCounterRepository.UpdateWordCounter(sa);
            string query = "insert into Words (UserId,FirstWord,SecondWord,Sentence,Image,DescriptionWord,ShowCounter,LanguageId) values (@userId,@firstWord,@secondWord,@sentence,@image,@descriptionWord,@showCounter,@languageId)";
            var paramaters = new DynamicParameters();
            paramaters.Add("userId", wordWithWordCounterDtos.UserId);
            paramaters.Add("firstWord", wordWithWordCounterDtos.FirstWord);
            paramaters.Add("secondWord", wordWithWordCounterDtos.SecondWord);
            paramaters.Add("sentence", wordWithWordCounterDtos.Sentence);
            paramaters.Add("image", wordWithWordCounterDtos.Image);
            paramaters.Add("descriptionWord", wordWithWordCounterDtos.DescriptionWord);
            paramaters.Add("showCounter", wordWithWordCounterDtos.ShowCounter);
            paramaters.Add("languageId", wordWithWordCounterDtos.LanguageId);
            
            
            using (var connection = _context.CreatConnection())

            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public void CreatWordChatGPT(WordWithWordCounterDtos wordWithWordCounterDtos)
        {
             var chatGptWords=_chatgptwords.GenerateInstagramPost();
             foreach(var words in chatGptWords.Result)
            {
                words.UserId = wordWithWordCounterDtos.UserId;
                words.LanguageId = wordWithWordCounterDtos.LanguageId;
                CreatWord(words);
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

        public async Task<List<ResultWordDto>> GetAllWord(int id)
        {
            string query = $"Select * From Words Where UserId ={id} Order by WordId asc";
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

        public async void UpdateWordshowcounter(int id)   
        {
            var showcounter=GetWordId(id).Result.ShowCounter;
            showcounter = showcounter + 1;
            string query = "Update Words Set ShowCounter=@showCounter where WordId=@wordId";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordId", id);
            paramaters.Add("showCounter", showcounter);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
