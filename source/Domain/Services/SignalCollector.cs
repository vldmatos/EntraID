using Domain.Models;

namespace Domain.Services
{
    public class SignalCollector
    {
        public List<Device> Collect(List<Device> devices)
        {
            foreach (var device in devices)
            {
                device.Signal = Random.Shared.NextDouble();
            }

            return devices;
        }
    }
}
