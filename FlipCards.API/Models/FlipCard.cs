namespace FlipCards.API.Models
{
    public class FlipCard
    {
        public int Id { get; set; }
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
    }

}
