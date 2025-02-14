using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Entities.Animals
{
    public class Rabbit : Herbo
    {
        public Rabbit(string name, int food, bool state, int Kindness) : base(name, food, state, Kindness) { }
    }
}
