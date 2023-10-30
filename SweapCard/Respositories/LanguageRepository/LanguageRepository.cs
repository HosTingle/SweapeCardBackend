using Dapper;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.LanguageDtos;
using SweapCard.Dtos.LearnWordDtos;

namespace SweapCard.Respositories.LanguageRepository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly Context _context;

        public LanguageRepository(Context context)
        {
            _context = context;
        }

        public async void CreatLanguage(ResultLanguageDto creatLanguageDto)
        {
            string query = "insert into Language (LanguageFirstName,LanguageSecondName) values (@languageFirstName,@languageSecondName)";
            var paramaters = new DynamicParameters();
            paramaters.Add("languageFirstName", creatLanguageDto.LanguageFirstName);
            paramaters.Add("languageSecondName", creatLanguageDto.LanguageSecondName);
   
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteLanguage(int id)
        {
            string query = "Delete From Language Where LanguageId=@languageId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@languageId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLanguageDto>> GetAllLanguage()
        {
            string query = "Select * From Language";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultLanguageDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultLanguageDto> GetLanguageId(int id)
        {
            string query = "Select * From Language Where LanguageId=@languageId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@languageId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultLanguageDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateLanguage(ResultLanguageDto updateLanguageDto)
        {
            string query = "Update Language Set LanguageFirstName=@languageFirstName,LanguageSecondName=@languageSecondName where LanguageId=@languageId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@languageId", updateLanguageDto.LanguageId);
            paramaters.Add("@languageFirstName", updateLanguageDto.LanguageFirstName);
            paramaters.Add("@languageSecondName", updateLanguageDto.LanguageSecondName);

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
