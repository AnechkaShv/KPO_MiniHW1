using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Things
{
    public abstract class Thing : IThing, IInventory
    {
        public int Number { get; set; }

        public Thing() 
        {
        }

        public override string ToString()
        {
            return $"Thing is {this.GetType().Name}, number is {this.Number}";
        }
    }
}
