using Domain.Abstractions;
using Domain.Entities.Things;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ThingsRepository : IThingRepository
    {
        private List<Thing> _things = new List<Thing> ();
        public void Add(Thing thing)
        {
            _things.Add (thing);
        }

        public void Remove(Thing thing)
        {
            _things.Remove (thing);
        }

        public List<Thing> Things { get; }

    }
}
