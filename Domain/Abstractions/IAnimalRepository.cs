using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Animals;

namespace Domain.Abstractions
{
    public interface IAnimalRepository
    {
        void Add(Animal animal);
        void Remove(Animal animal);

        List<Animal> Animals{get;}
    }
}
