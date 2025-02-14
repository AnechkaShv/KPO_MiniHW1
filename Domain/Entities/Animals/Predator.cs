using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Animals
{
    public class Predator : Animal
    {
        public Predator(string name, int food, bool stateOfHealth) : base(name, food, stateOfHealth)
        {

        }
    }
}
