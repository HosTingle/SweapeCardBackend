using Dapper;
using RealEstate_Dapper.Dtos.UserDtos;
using RealEstate_Dapper.Models.DapperContext;
using SweapCard.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;

namespace RealEstate_Dapper.Respositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        } 

        public async void CreatUser(CreatUserDto userDto)
        {
            string query = "insert into Users (AvatarId,Username,Password,Name,Surname,BirthDate,Phone,Description,ScoreId,Status,WordCounterId) values (@avatarId,@userName,@password,@name,@surname,@birthDate,@phone,@description,@scoreId,@status,@wordCounterId)";
            var paramaters = new DynamicParameters();
            paramaters.Add("avatarId", userDto.AvatarId);
            paramaters.Add("userName", userDto.Username);
            paramaters.Add("password", userDto.Password);
            paramaters.Add("name", userDto.Name);
            paramaters.Add("surname", userDto.Surname);
            paramaters.Add("birthDate", userDto.BirthDate);
            paramaters.Add("phone", userDto.Phone);
            paramaters.Add("description", userDto.Description);
            paramaters.Add("scoreId", userDto.AvatarId);
            paramaters.Add("status", true);
            paramaters.Add("wordCounterId", userDto.WordCounterId);
            using(var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async void DeleteUser(int id)
        {
            string query = "Delete From Users Where UserId=@userId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@userId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultUserDto>> GetAllUser()
        {
            string query = "Select * From Users";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultUserDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultUserWithOtherDto>> GetAllUserWithOther()
        {
            string query = "Select UserId,ImagePath,Username,Password,Name,Surname,BirthDate,Phone,Description,Score,Status,WordCounter From Users inner join Avatars on Users.AvatarId=Avatars.AvatarId inner join Score on Users.ScoreId=Score.ScoreId inner join WordCounter on Users.WordCounterId=WordCounter.WordCounterId ";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<ResultUserWithOtherDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdUserDto> GetUserId(int id)
        {
            string query = "Select * From Users Where UserId=@userId";
            var parameters= new DynamicParameters(query);
            parameters.Add("@userId", id);
            using( var connection = _context.CreatConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIdUserDto>(query,parameters);
                return values;
            }

        }

        public async void UpdateUser(UpdateUserDto userDto)
        {
            string query = "Update Users Set AvatarId=@avatarId,Username=@userName,Password=@password,Name=@name,Surname=@surname,BirthDate=@birthDate,Phone=@phone,Description=@description,ScoreId=@scoreId,Status=@status,WordCounterId=@wordCounterId where UserId=@userId";
            var paramaters= new DynamicParameters();
            paramaters.Add("@userId", userDto.UserId);
            paramaters.Add("@avatarId", userDto.AvatarId);
            paramaters.Add("@userName", userDto.Username);
            paramaters.Add("@password", userDto.Password);
            paramaters.Add("@name", userDto.Name);
            paramaters.Add("@surname", userDto.Surname);
            paramaters.Add("@birthDate", userDto.BirthDate);
            paramaters.Add("@phone", userDto.Phone);
            paramaters.Add("@description", userDto.Description);
            paramaters.Add("@scoreId", userDto.AvatarId);
            paramaters.Add("@status", userDto.Status);
            paramaters.Add("@wordCounterId", userDto.WordCounterId);
            using(var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }
    }
}
