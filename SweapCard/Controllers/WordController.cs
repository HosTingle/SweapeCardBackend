using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.UserDtos;
using SweapCard.Dtos.WordDtos;
using SweapCard.Respositories.WordRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        [HttpGet("getallWord")]
        public async Task<IActionResult> WordList(int id)
        {
            var values = await _wordRepository.GetAllWord(id);
            return Ok(values);
        }
        [HttpPost("CreatWord")]
        public async Task<IActionResult> CreatWord(WordWithWordCounterDtos wordWithWordCounterDtos)
        {
            _wordRepository.CreatWord(wordWithWordCounterDtos);
            return Ok("Word Oluşturuldu");
        }
        [HttpDelete("DeleteWord")]
        public async Task<IActionResult> DeleteWord(int id)
        { 
            _wordRepository.DeleteWord(id);
            return Ok("Word başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateWord")]
        public async Task<IActionResult> UpdateWord(UpdateWordDtos updateWordDto)
        {
            _wordRepository.UpdateWord(updateWordDto);
            return Ok("Word başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByWordId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _wordRepository.GetWordId(id);
            return Ok(value);
        }
        [HttpGet("WordListWithUser")]
        public async Task<IActionResult> WordListWithUser()
        {
            var values = await _wordRepository.GetAllWordWithUser();
            return Ok(values);
        }
        [HttpPost("CreatWitChatGpt")]
        public async Task<IActionResult> CreatWitChatGpt(WordWithWordCounterDtos wordWithWordCounterDtos)
        {
            _wordRepository.CreatWordChatGPT(wordWithWordCounterDtos);
            return Ok("Word Oluşturuldu");
        }
        [HttpPut("UpdateWordshowcounter")]
        public async Task<IActionResult> UpdateWordshowcounter(int id)
        {
            _wordRepository.UpdateWordshowcounter(id); 
            return Ok("Word'ün counterı başarılı bir şekilde güncellendi");
        }


    }
}
