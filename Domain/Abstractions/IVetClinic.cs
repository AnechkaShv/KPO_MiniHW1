﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IVetClinic
    {
        bool CheckHealth(IAlive animal);
    }
}
