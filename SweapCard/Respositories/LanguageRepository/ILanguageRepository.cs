using SweapCard.Dtos.LanguageDtos;
using SweapCard.Dtos.LearnWordDtos;

namespace SweapCard.Respositories.LanguageRepository
{
    public interface ILanguageRepository
    {
        Task<List<ResultLanguageDto>> GetAllLanguage(); 
        void CreatLanguage(ResultLanguageDto creatLanguageDto);  
        void DeleteLanguage(int id); 
        void UpdateLanguage(ResultLanguageDto updateLanguageDto);  
        Task<ResultLanguageDto> GetLanguageId(int id); 
    }
}
