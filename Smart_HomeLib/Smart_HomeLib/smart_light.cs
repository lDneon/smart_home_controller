using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_HomeLib
{
    public  class smart_light : iot_device
    {
        private int brightness;  
        private string color;

        public smart_light(string deviceid, string name) : base(deviceid, name)
        {
            brightness = 0;
            color = "White";
        }

        public void SetBrightness(int level)
        {
            if (!IsPoweredOn)
                throw new InvalidOperationException("Light must be powered on to set brightness.");

            if (level < 0 || level > 100)
                throw new ArgumentOutOfRangeException(nameof(level), "Brightness must be between 0 and 100.");

            brightness = level;
        }

        public void SetColor(string newColor)
        {
            if (!IsPoweredOn)
                throw new InvalidOperationException("Light must be powered on to set color.");
            
            if (string.IsNullOrWhiteSpace(newColor))
                throw new ArgumentException("Color cannot be blank.", nameof(newColor));
            color = newColor.Trim();
        }

        public override string GetStatus()
        {
            return $"Smart Light '{Name}' (ID: {DeviceId}) - Online: {IsOnline}, Powered On: {IsPoweredOn}, Brightness: {brightness}, Color: {color}";
        }

        public override void ApplyMode(string mode)
        {
            if (mode == "Night" && IsPoweredOn)
            {
                brightness = 10;
            }
        }
    }
}
