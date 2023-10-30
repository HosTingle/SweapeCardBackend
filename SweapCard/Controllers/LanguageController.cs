using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweapCard.Dtos.LanguageDtos;
using SweapCard.Dtos.LearnWordDtos;
using SweapCard.Respositories.LanguageRepository;
using SweapCard.Respositories.LearnWordRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        [HttpGet("getallLanguage")]
        public async Task<IActionResult> GetallLearnLanguage()  
        {
            var values = await _languageRepository.GetAllLanguage();
            return Ok(values);
        }
        [HttpPost("CreateLanguage")]
        public async Task<IActionResult> CreatLanguage(ResultLanguageDto resultLanguageDto)
        {
            _languageRepository.CreatLanguage(resultLanguageDto);
            return Ok("Language Oluşturuldu");
        }
        [HttpDelete("DeleteLanguage")]
        public async Task<IActionResult> DeleteLanguage(int id) 
        {
            _languageRepository.DeleteLanguage(id);
            return Ok("Language başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateLanguage")]
        public async Task<IActionResult> UpdateLanguage(ResultLanguageDto resultLanguageDto)
        {
            _languageRepository.UpdateLanguage(resultLanguageDto);
            return Ok("Language başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByLanguageId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _languageRepository.GetLanguageId(id);
            return Ok(value);
        }
    }
}
