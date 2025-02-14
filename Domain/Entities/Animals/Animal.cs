using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Entities.Animals
{
    
    public abstract class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }

        public string? Name { get; set; }

        public bool State { get; set; }

        public Animal(string name, int food, bool state)
        {
            Name = name;
            Food = food;
            State = state;
        }

        public override string ToString()
        {
            return $"Name is {Name}; Food is {Food}; Number is {Number}, State of health is {State} \n ";
        }
    }
}
