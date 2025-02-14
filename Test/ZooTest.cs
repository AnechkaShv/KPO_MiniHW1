using Xunit;
using Moq;
using Domain.Abstractions;
using Domain.Entities.Animals;
using Domain.Entities.Things;
using Domain.Services;
using Assert = Xunit.Assert;

namespace Test;

public class ZooTest
{
    private readonly Mock<IVetClinic> _vetClinicMock;
    private readonly Mock<IAnimalRepository> _animalRepositoryMock;
    private readonly Mock<IThingRepository> _thingRepositoryMock;

    public ZooTest()
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
        Xunit.Assert.NotNull(animals);
        Xunit.Assert.Empty(animals);
    }

    [Fact]
    public void Add_Healthy_Animal()
    {
        // Arrange
        Animal animal = new Wolf("Lisa", 2, true);
        _vetClinicMock.Setup(vetClinic => vetClinic.CheckHealth(animal)).Returns(true);
        _animalRepositoryMock.Setup(animalRepository => animalRepository.Add(animal));
        
        //Act
        Zoo zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        var res = zoo.AddAnimal(animal);
        
        Assert.True(res);
        _animalRepositoryMock.Verify(arr => arr.Add(animal), Times.Once);

    }
    
    [Fact]
    public void Add_Unhealthy_Animal()
    {
        // Arrange
        var animal = new Monkey("Kolya", 5, false, 3);
        _vetClinicMock.Setup(vc => vc.CheckHealth(animal)).Returns(false);
        _animalRepositoryMock.Setup(ar => ar.Add(animal)).Verifiable();

        // Act
        var zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        var result = zoo.AddAnimal(animal);

        // Assert
        Assert.False(result);
        _animalRepositoryMock.Verify(ar => ar.Add(animal), Times.Never);
    }

    [Fact]
    public void AddThing()
    {
        // Arrange
        var thing = new Table();
        _thingRepositoryMock.Setup(tr => tr.Add(thing)).Verifiable();

        // Act
        var zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        zoo.AddThing(thing);

        // Assert
        _thingRepositoryMock.Verify(tr => tr.Add(thing), Times.Once);
    }

    [Fact]
    public void Check_SumOfFoodForAllAnimals()
    {
        // Arrange
        var animal1 = new Tiger("Alex", 10, true);
        var animal2 = new Rabbit("Krosh", 20, true, 3);
        _animalRepositoryMock.Setup(ar => ar.Animals).Returns(new List<Animal> { animal1, animal2 });

        // Act
        var zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        var result = zoo.Food();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Get_Contact_Animals()
    {
        // Arrange
        var animal1 = new Monkey("Ivan", 4, true, 2);
        var animal2 = new Rabbit("Ann", 6, true, 6);
        var animal3 = new Wolf("Jakob", 8, true);
        _animalRepositoryMock.Setup(ar => ar.Animals).Returns(new List<Animal> { animal1, animal2, animal3 });

        // Act
        var zoo = new Zoo(_vetClinicMock.Object, _animalRepositoryMock.Object, _thingRepositoryMock.Object);
        var result = zoo.GetContactAnimals();

        // Assert
        Assert.Single(result);
    }
    
    [Fact]
    public void Herbo_Kindness_OutOfRange_ThrowsException()
    {
        var herboMock = new Rabbit("Vilina", 3, true, 11);

        Assert.Equal(10, herboMock.Kindness);
    }
}