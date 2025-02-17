using Domain.Models;

namespace Domain.Services
{
    public class SignalCollector
    {
        public Device[] Collect(Device[] devices)
        {
            foreach (var device in devices)
            {
                device.Signal = Random.Shared.NextDouble();
            }

            return devices;
        }
    }
}
