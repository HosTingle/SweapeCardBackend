using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweapCard.Dtos.AvatarDtos;
using SweapCard.Dtos.ScoreDtos;
using SweapCard.Respositories.AvatarRepository;
using SweapCard.Respositories.ScoreRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository ;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [HttpGet("getallScore")] 
        public async Task<IActionResult> GetallAvatars()
        {
            var values = await _scoreRepository.GetAllScore();
            return Ok(values);
        }
        [HttpPost("CreateScore")]
        public async Task<IActionResult> CreatScore()
        {
            _scoreRepository.CreatScore();
            return Ok("Score Oluşturuldu");
        }
        [HttpDelete("DeleteScore")]
        public async Task<IActionResult> DeleteScore(int id) 
        {
            _scoreRepository.DeleteScore(id);
            return Ok("Score başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateScore")]
        public async Task<IActionResult> UpdateScore(ResultScoreDto resultScoreDto)
        {
            _scoreRepository.UpdateScore(resultScoreDto);
            return Ok("Score başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByScoreId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _scoreRepository.GetScoreId(id);
            return Ok(value);
        }
    }
}
