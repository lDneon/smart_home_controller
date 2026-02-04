using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_HomeLib
{
    public class Temperature : iot_device
    {
        private int thermostat_temp;

        public Temperature(string deviceid, string name) : base(deviceid, name)
        {
            thermostat_temp = 20;
        }

        public void SetTemperature(int temp) 
        { 
            if (!IsPoweredOn)
                throw new InvalidOperationException("Thermostat must be powered on to set temperature.");
            
            if (temp < 50 || temp > 90)
                throw new ArgumentOutOfRangeException(nameof(temp), 
                    "Temperature must be between 50 and 90 degrees Fahrenheit.");

            thermostat_temp = temp;
        }

        public override string GetStatus()
        {
            return $"Thermostat [{Name}] | Power: {IsPoweredOn}| Temp: {thermostat_temp}";
        }

        public override void ApplyMode(string mode)
        {
            if (mode == "Night" && IsPoweredOn)
            {
                thermostat_temp = 65;
            }
        }
    }
}
