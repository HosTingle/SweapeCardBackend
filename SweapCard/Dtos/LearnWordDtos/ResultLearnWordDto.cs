namespace SweapCard.Dtos.LearnWordDtos
{
    public class ResultLearnWordDto
    {
        public int LearnWordId { get; set; }
        public string LearnWordFirst { get; set; }
        public string LearnWordSecond { get; set; }
        public string LearnWordSentence { get; set; }

        public int UserId { get; set; }
    }
}
