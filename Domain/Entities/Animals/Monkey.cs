using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Entities.Animals
{
    public class Monkey : Herbo
    {
        public Monkey(string name, int food, bool state, int kindness) : base(name, food, state, kindness) { }
    }
}
