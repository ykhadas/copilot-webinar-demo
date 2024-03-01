using Xunit;
using FluentAssertions;
using Moq;
using WrightBrothersApi.DAL;
using WrightBrothersApi.Models;
using WrightBrothersApi.UseCases;
using System.Collections.Generic;

namespace WrightBrothersApi.Tests.UseCases
{
    public class PlanesUseCaseTests
    {
        private readonly Mock<IDataStore> _mockDataStore;
        private readonly PlanesUseCase _planesUseCase;

        public PlanesUseCaseTests()
        {
            _mockDataStore = new Mock<IDataStore>();
            _planesUseCase = new PlanesUseCase(_mockDataStore.Object);
        }

        [Fact]
        public void GetPlanes_ShouldReturnAllPlanes()
        {
            var planes = new List<Plane> { new Plane(), new Plane() };
            _mockDataStore.Setup(ds => ds.GetPlanes()).Returns(planes);

            var result = _planesUseCase.GetPlanes();

            result.Should().BeEquivalentTo(planes);
        }

        [Fact]
        public void GetPlane_ShouldReturnPlaneById()
        {
            var plane = new Plane { Id = 1 };
            _mockDataStore.Setup(ds => ds.GetPlane(It.IsAny<int>())).Returns(plane);

            var result = _planesUseCase.GetPlane(1);

            result.Should().BeEquivalentTo(plane);
        }

        [Fact]
        public void AddPlane_ShouldAddPlaneToDataStore()
        {
            var plane = new Plane();
            _mockDataStore.Setup(ds => ds.AddPlane(It.IsAny<Plane>()));

            _planesUseCase.AddPlane(plane);

            _mockDataStore.Verify(ds => ds.AddPlane(plane), Times.Once);
        }

        [Fact]
        public void AMethod_ShouldSortPlanesByYear()
        {
            var planes = new List<Plane>
            {
                new Plane { Year = 2002 },
                new Plane { Year = 1999 },
                new Plane { Year = 2000 }
            };

            _planesUseCase.AMethod(planes);

            planes[0].Year.Should().Be(1999);
            planes[1].Year.Should().Be(2000);
            planes[2].Year.Should().Be(2002);
        }
    }
}
