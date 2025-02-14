using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Domain.Abstractions;
using Domain.Services;
using Domain.Repositories;

public class Configuration
{
    public static (ServiceProvider, Zoo) Configurate()
    {
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<Zoo>()
            .AddSingleton<IVetClinic, VetClinic>()
            .AddSingleton<IAnimalRepository, AnimalsRepository>()
            .AddSingleton<IThingRepository, ThingsRepository>()
            .BuildServiceProvider();

        Zoo zoo = serviceProvider.GetService<Zoo>();
        return (serviceProvider, zoo);
    }
}
