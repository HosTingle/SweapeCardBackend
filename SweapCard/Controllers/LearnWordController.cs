using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.UserDtos;
using RealEstate_Dapper.Respositories.UserRepository;
using SweapCard.Dtos.LearnWordDtos;
using SweapCard.Respositories.LearnWordRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnWordController : ControllerBase
    {
        private readonly ILearnWordRepository _learnWordRepository;

        public LearnWordController(ILearnWordRepository learnWordRepository)
        {
            _learnWordRepository = learnWordRepository;
        }

        [HttpGet("getallLearnWord")]
        public async Task<IActionResult> LearnWordList() 
        {
            var values = await _learnWordRepository.GetAllLearnWord();
            return Ok(values);
        }
        [HttpPost("CreatLearnWord")]
        public async Task<IActionResult> CreatLearnWord(CreatLearnWordDto creatLearnWordDto)
        {
            _learnWordRepository.CreatLearnWord(creatLearnWordDto);
            return Ok("LearnWord Oluşturuldu");
        }
        [HttpDelete("DeleteLearnWord")]
        public async Task<IActionResult> DeleteUser(int id)
        { 
            _learnWordRepository.DeleteLearnWord(id);
            return Ok("LearnWord başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateLearnWordDto updateLearnWordDto)
        {
            _learnWordRepository.UpdateLearnWord(updateLearnWordDto);
            return Ok("LearnWord başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByLearnWordId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _learnWordRepository.GetLearnWordId(id);
            return Ok(value);
        }
     
    }
}
