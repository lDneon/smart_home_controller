using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_HomeLib
{
    public class Smart_homehub
    {
        private readonly List<iot_device> _devices = new();

        public IReadOnlyList<iot_device> Devices => new ReadOnlyCollection<iot_device>(_devices);

        public void AddDevice(iot_device device)
        {
            if (device is null)
                throw new ArgumentNullException(nameof(device));

            if (_devices.Any(d => d.DeviceId == device.DeviceId))
                throw new InvalidOperationException($"A device with id '{device.DeviceId}' already exists.");

            _devices.Add(device);
        }

        public bool RemoveDevice(string deviceId)
        {
            var device = _devices.FirstOrDefault(d => d.DeviceId == deviceId);
            if (device is null) return false;
            _devices.Remove(device);
            return true;
        }

        public void TurnOffAll()
        {
            foreach (var device in _devices)
                device.TurnOff();
        }

        public void ApplyModeToAll(string mode)
        {
            foreach (var device in _devices)
                device.ApplyMode(mode);
        }

        public void PrintAllStatuses()
        {
            foreach (var device in _devices)
                Console.WriteLine(device.GetStatus());
        }
    }
}

