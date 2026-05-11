namespace myKisah.Models
{
    public class CharacterResponse
    {
        public string Id { get; set; } = string.Empty;
        public string CharacterId { get; set; } = string.Empty;
        public MoodType Mood { get; set; }
        public string Response { get; set; } = string.Empty;
    }
}