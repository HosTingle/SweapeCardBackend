namespace SweapCard.Dtos.UserDtos
{
    public class GetByIdUserDto
    {
        public int UserId { get; set; }
        public int AvatarId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int ScoreId { get; set; }
        public bool Status { get; set; }
        public int WordCounterId { get; set; }
    }
}
