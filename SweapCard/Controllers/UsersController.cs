using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.UserDtos;
using RealEstate_Dapper.Respositories.UserRepository;
using SweapCard.Dtos.UserDtos;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("getallUser")]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _userRepository.GetAllUser();
            return Ok(values);
        }
        [HttpPost("CreatUser")]
        public async Task<IActionResult> CreatUser(CreatUserDto creatUserDto)
        {
            _userRepository.CreatUser(creatUserDto);
            return Ok("User Oluşturuldu");
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok("User başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            _userRepository.UpdateUser(updateUserDto);
            return Ok("User başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByUserId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value=await _userRepository.GetUserId(id);
            return Ok(value);
        }
        [HttpGet("WordListWithOther")]
        public async Task<IActionResult> WordListWithUser()
        {
            var values = await _userRepository.GetAllUserWithOther();
            return Ok(values);
        }
        [HttpGet("{id}GetByUserWithOtherId")]
        public async Task<IActionResult> GetByUserWithOtherId(int id)
        {
            var value = await _userRepository.GetUserWithOtherId(id);
            return Ok(value);
        }
    }
}
