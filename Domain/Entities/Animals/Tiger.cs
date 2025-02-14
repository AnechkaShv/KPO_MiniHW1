using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Animals
{
    public class Tiger : Predator
    {
        public Tiger(string name, int food, bool state) : base(name, food, state) { }

    }
}
