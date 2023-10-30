using Dapper;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.AvatarDtos;
using SweapCard.Dtos.LanguageDtos;

namespace SweapCard.Respositories.AvatarRepository
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly Context _context;

        public AvatarRepository(Context context)
        {
            _context = context;
        }

        public async void CreatAvatar(ResultAvatarDto resultAvatarDto) 
        {
            string query = "insert into Avatars (ImagePath) values (@imagePath)";
            var paramaters = new DynamicParameters();
            paramaters.Add("imagePath", resultAvatarDto.ImagePath);
           

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteAvatar(int id)
        {
            string query = "Delete From Avatars Where AvatarId=@avatarId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@avatarId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAvatarDto>> GetAllAvatar()
        {
            string query = "Select * From Avatars";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultAvatarDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultAvatarDto> GetAvatarId(int id)
        {
            string query = "Select * From Avatars Where AvatarId=@avatarId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@avatarId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAvatarDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateAvatar(ResultAvatarDto updateLanguageDto)
        {
            string query = "Update Avatars Set ImagePath=@imagePath where AvatarId=@avatarId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@avatarId", updateLanguageDto.AvatarId);
            paramaters.Add("@imagePath", updateLanguageDto.ImagePath);
         

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
