using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Animals
{
    public class Wolf : Predator
    {
        public Wolf(string name, int food, bool state) : base(name, food, state) { }
    }
}
