namespace SecretSanta.Api.Dto
{
    public class NewGift
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
    }
}