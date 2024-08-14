using Core.Domains.Cars.Services;
using Core.Domains.Cars.Models;
using Moq;
using FluentAssertions;


namespace Tests;

public class CarDayInfoRepositoryTests
{
    public Mock<ICarDayInfoKeeper> carDayInfoKeeperMoq = new();

    public ICarDayInfoRepository Service { get; set; }

    public CarDayInfoRepositoryTests()
    {
        Service = new CarDayInfoRepository(
            carDayInfoKeeperMoq.Object);
    }

    [Fact]
    public async Task Get_ById_CarDayInfoKeeperGetMethodCalled()
    {
        // Arrange
        var id = Guid.NewGuid();

        carDayInfoKeeperMoq.Setup(service => service.Get(It.IsAny<Guid>()))
            .ReturnsAsync(new CarDayInfo() { Id = id });

        // Act
        await Service.Get(id);

        // Assert
        carDayInfoKeeperMoq.Verify(service => service.Get(id), Times.Once);
    }

    [Fact]
    public async Task Create_CarDayInfo_CheckIdAndDescriptionNotEmpty()
    {
        // Arrange
        var description = "";

        var carDayInfo = new CarDayInfo
        {
            Description = description,
            Date = DateOnly.FromDateTime(DateTime.Now),
            Cars = new()
            {
                new Car()
                {
                    Number = "111"
                }
            }
        };

        carDayInfoKeeperMoq.Setup(service => service.Create(It.IsAny<CarDayInfo>()))
            .ReturnsAsync(true);

        // Act
        var newCarDayInfo = await Service.Create(carDayInfo);

        // Assert
        newCarDayInfo.Id
            .Should()
            .NotBeEmpty();
        Guid.TryParse(newCarDayInfo.Id.ToString(), out _)
            .Should()
            .BeTrue();
        newCarDayInfo.Description
            .Should()
            .NotBe(description);

        carDayInfoKeeperMoq.Verify(service => service.Create(It.IsAny<CarDayInfo>()), Times.Once);
    }
}