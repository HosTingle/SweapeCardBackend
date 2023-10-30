namespace SweapCard.Dtos.WordDtos
{
    public class ResultWordWithUserDto
    {
        public int WordId { get; set; }
        public string UserName { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public string Sentence { get; set; }
        public string Image { get; set; }
        public string DescriptionWord { get; set; }
        public int ShowCounter { get; set; }
        public int LanguageId { get; set; }
    }
}
