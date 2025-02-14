using Domain.Entities.Animals;
using Domain.Abstractions;

namespace Domain.Repositories
{
    public class AnimalsRepository : IAnimalRepository
    {
        private List<Animal> _animals = new List<Animal>();

        public void Add(Animal animal)
        {
            _animals.Add(animal);
        }

        public void Remove(Animal animal)
        {
            if (_animals.Any() && _animals.Contains(animal))
            {
                _animals.Remove(animal);
            }
        }

        public List<Animal> Animals { get{return _animals;}  }
    }
}