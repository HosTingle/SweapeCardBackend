using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweapCard.Dtos.AvatarDtos;
using SweapCard.Dtos.LanguageDtos;
using SweapCard.Respositories.AvatarRepository;
using SweapCard.Respositories.LanguageRepository;

namespace SweapCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarRepository _avatarRepository;

        public AvatarController(IAvatarRepository avatarRepository)
        {
            _avatarRepository = avatarRepository;
        }

        [HttpGet("getallAvatars")]
        public async Task<IActionResult> GetallAvatars() 
        {
            var values = await _avatarRepository.GetAllAvatar();
            return Ok(values);
        }
        [HttpPost("CreateAvatar")]
        public async Task<IActionResult> CreatAvatar(ResultAvatarDto resultAvatarDto)
        {
            _avatarRepository.CreatAvatar(resultAvatarDto);
            return Ok("Avatar Oluşturuldu");
        }
        [HttpDelete("DeleteAvatar")]
        public async Task<IActionResult> DeleteAvatar(int id)
        {
            _avatarRepository.DeleteAvatar(id);
            return Ok("Avatar başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateAvatar")]
        public async Task<IActionResult> UpdateAvatar(ResultAvatarDto resultAvatarDto)
        {
            _avatarRepository.UpdateAvatar(resultAvatarDto);
            return Ok("Avatar başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByAvatarId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _avatarRepository.GetAvatarId(id);
            return Ok(value);
        }
    }
}
