using Domain.Entities.Animals;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Interface;

class Program
{

    public static void Main(string[] args)
    {

        var service = Configuration.Configurate();
        ServiceProvider serviceProvider = service.Item1;
        Zoo zoo = service.Item2;

        MainInterface menu = new MainInterface();
        menu.ShowMenu(zoo);
    }
}