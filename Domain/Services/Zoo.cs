using Domain.Abstractions;
using Domain.Entities.Things;
using Domain.Entities.Animals;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class Zoo
    {
        private IVetClinic _vetClinic;
        private IAnimalRepository _animalRepository;
        private IThingRepository _thingRepository;
        private int _numberAnimal = 1;
        private int _numberThings = 1;
        
        /// <summary>
        /// This constractor initializes interface members with association.
        /// </summary>
        /// <param name="vetClinic_"></param>
        /// <param name="animalRepository_"></param>
        /// <param name="thingRepository_"></param>
        public Zoo(IVetClinic vetClinic, IAnimalRepository animalRepository, IThingRepository thingRepository)
        {
            // Dependency Injection.
            this._vetClinic = vetClinic;
            this._animalRepository = animalRepository;
            this._thingRepository = thingRepository;
        }

        /// <summary>
        /// This method returns list of animals.
        /// </summary>
        /// <returns></returns>
        public List<Animal> GetAnimals()
        {
            return _animalRepository.Animals;
        }
        /// <summary>
        /// This method returns list of things.
        /// </summary>
        /// <returns></returns>
        public List<Thing> GetThings()
        {
            return _thingRepository.Things;
        }
        /// <summary>
        /// This method verify animal's health and add it.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckHealth(animal))
            {
                // Adding animal.
                _animalRepository.Add(animal);
                
                // Setting number of animal.
                animal.Number = _numberAnimal;
                
                // Increasing amount of animals.
                _numberAnimal += 1;
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method adds thing.
        /// </summary>
        /// <param name="thing"></param>
        public void AddThing(Thing thing)
        {
            // Adding thing.
            _thingRepository.Add(thing);
            
            // Setting number counter of thing.
            thing.Number = _numberThings;
            
            // Increasing the amount of things.
            _numberThings += 1;
        }

        /// <summary>
        /// This method returns the amount of food for all animals in the zoo.
        /// </summary>
        /// <returns></returns>
        public int Food()
        {
            int sum = 0;
            List<Animal> animals = _animalRepository.Animals;
            
            // Summing necessary amount of food for each animal.
            for (int i = 0; i < animals.Count(); i++)
            {
                sum += animals[i].Food;
            }
            return sum;
        }

        /// <summary>
        /// This method returns list of animals whose kindness is more than 5.
        /// </summary>
        /// <returns></returns>
        public List<Animal> GetContactAnimals()
        {
            List<Animal> animals = new List<Animal>();
            for (int i = 0; i < _animalRepository.Animals.Count(); i++)
            {
                // Checking is animal is herbo and its kindness if it is.
                if (_animalRepository.Animals[i] is Herbo && ((Herbo)_animalRepository.Animals[i]).Kindness > 5)
                {
                    animals.Add((Animal)_animalRepository.Animals[i]);
                }
            }
            return animals;
        }
    }
}
