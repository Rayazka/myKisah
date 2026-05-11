using myKisah.Models;

namespace myKisah.Repository.Interfaces
{
    public interface ICharacterResponseRepository : IRepository<CharacterResponse>
    {
        IEnumerable<CharacterResponse> GetByMood(string characterId, MoodType mood);
    }
}
