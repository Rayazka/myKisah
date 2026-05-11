using myKisah.Models;
using myKisah.Utils;

namespace myKisah.Repository
{
    public class JsonCharacterRepository
    {
        public class JsonCharacterResponseRepository : ICharacterRepository
        {
            private readonly JsonStorageHelper _storage;
            private readonly FilePathConfig _filePath;

            public JsonCharacterResponseRepository(JsonStorageHelper stroge, FilePathConfig filePath)
            {
                _stroge = stroge;
                _filePath = filePath;
            }
            public IEnumerable<Character> GetAll() { 
                return _storage.ReadJson<Character>(_filePath.CharacterFile);
                }
            public void add(Character entity)
            {
                var characters = GetAll().ToList();
                entity.id = Guid.NewGuid().ToString();
                characters.Add(entity);
                _storage.WriteJson(_filePath.CharacterFile, characters);
            }
        
            public void Update(Character entity)
            {
                var characters = GetAll().ToList();
                var index = characters.FindIndex(c => c.id == entity.id);
                if (index == -1)
                    throw new KeyNotFoundException("Character dengan Id '{entity.Id}' tidak ditemukan.");
                characters {index} = entity;
                _storage.WriteJson(_filePath.CharacterFile, characters);
            }
            public void Delete(string id) 
                {
                    var characters = GetAll().ToList();
                    characters.RemoveAll(c => c.id == id);
                    _storage.WriteJson(_filePath.CharacterFile, characters);
                }
                public Character GetById(string name) {
                    return GetAll().FirstOrDefault(c => c.name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
        }
    }
}

