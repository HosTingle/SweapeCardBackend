using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweapCard.Dtos.WordCounterDtos;
using SweapCard.Dtos.WordDtos;
using SweapCard.Respositories.WordCounterRepository;
using SweapCard.Respositories.WordRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCounterController : ControllerBase
    {
        private readonly IWordCounterRepository _wordCounterRepository;

        public WordCounterController(IWordCounterRepository wordCounterRepository)
        {
            _wordCounterRepository = wordCounterRepository;
        }

        [HttpGet("getallWordCounter")]
        public async Task<IActionResult> WordCounterList() 
        {
            var values = await _wordCounterRepository.GetAllWordCounter();
            return Ok(values);
        }
        [HttpPost("CreatWordCounter")]
        public async Task<IActionResult> CreatWordCounter()
        {
            _wordCounterRepository.CreatWordCounter();
            return Ok("WordCounter Oluşturuldu"); 
        }
        [HttpDelete("DeleteWordCounter")]
        public async Task<IActionResult> DeleteWordCounter(int id)
        {
            _wordCounterRepository.DeleteWordCounter(id);
            return Ok("WordCounter başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateWordCounter")]
        public async Task<IActionResult> UpdateWordCounter(UpdateWordCounterDto updateWordCounterDto)
        {
            _wordCounterRepository.UpdateWordCounter(updateWordCounterDto);
            return Ok("WordCounter başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByWordCounterId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _wordCounterRepository.GetWordCounterId(id);
            return Ok(value);
        }
    }
}
