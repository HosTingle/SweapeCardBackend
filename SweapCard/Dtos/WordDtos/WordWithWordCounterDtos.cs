using SweapCard.Dtos.WordCounterDtos;
using SweapCard.Respositories.WordCounterRepository;

namespace SweapCard.Dtos.WordDtos
{
    public class WordWithWordCounterDtos
    {
        /*CreatWordCounterDto _creatWordCounterDto;
        CreatWordDto _creatWordDto;
        public WordWithWordCounterDtos(CreatWordCounterDto creatWordCounterDto,CreatWordDto creatWordDto)
        { 
            _creatWordCounterDto = creatWordCounterDto;
            _creatWordDto = creatWordDto;   
            
        }*/
        public int WordId { get; set; }
        public int UserId { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public string Sentence { get; set; }
        public string Image { get; set; }
        public string DescriptionWord { get; set; }
        public int ShowCounter { get; set; }
        public int LanguageId { get; set; }
        public int WordCounterId { get; set; }
        public int WordCounter { get; set; }
        public int LearnWordCounter { get; set; }
    }
}
