using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Things;

namespace Domain.Abstractions
{
    public interface IThingRepository
    {
        void Add(Thing thing);
        void Remove(Thing thing);
        List<Thing> Things { get; }
    }
}
