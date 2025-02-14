using Xunit;
using Moq;
using Domain.Abstractions;
using Domain.Entities.Animals;
using Domain.Services;

namespace Tests;

public class ZooTests
{
    private readonly Mock<IVetClinic> _vetClinicMock;
    private readonly Mock<IAnimalRepository> _animalRepositoryMock;
    private readonly Mock<IThingRepository> _thingRepositoryMock;

    public ZooTests()
    {
        _vetClinicMock = new Mock<IVetClinic>();
        _animalRepositoryMock = new Mock<IAnimalRepository>();
        _thingRepositoryMock = new Mock<IThingRepository>();
    }

    [Fact]
    public void GetAnimals_ReturnsAnimals()
    {
        // Arange
        _animalRepositoryMock.Setup((arr => arr.Animals)).Returns((new List<Animal>()));
        
        // Act
        Zoo zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        var animals = zoo.GetAnimals();
        
        //Assert
        Assert.NotNull(animals);
        Assert.Empty(animals);
    }
}