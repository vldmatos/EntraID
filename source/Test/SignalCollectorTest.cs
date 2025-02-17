using Domain.Models;
using Domain.Services;

namespace Test
{
    public class SignalCollectorTest
    {
        [Fact]
        public void Collect_ShouldSetSignalGreaterThanZero()
        {
            // Arrange
            var devices = new[]
            {
                new Device { Name = "Device1" },
                new Device { Name = "Device2" }
            };
            var signalCollector = new SignalCollector();

            // Act
            var result = signalCollector.Collect(devices);

            // Assert
            Assert.All(result, device => Assert.True(device.Signal > 0, $"Device {device.Name} has Signal {device.Signal}"));
        }
    }
}
