using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_HomeLib;


//var hub = new Smart_homehub();

class Program
{
    static void Main()
    {
        smart_light bulb = new smart_light("bulb001", "Living Room Bulb");
        smart_light bulb2 = new smart_light("bulb002", "Bedroom Bulb");
        smart_light bulb3 = new smart_light("bulb003", "Kitchen Bulb");

        List<iot_device> devices = new List<iot_device>
        {
            bulb,
            bulb2,
            bulb3
        };

        foreach (iot_device device in devices)
        {
            device.SetOnline(true);
        }

        foreach (iot_device device in devices)
        {
            device.TurnOn();
            device.ApplyMode("Reading");
            Console.WriteLine(device.GetStatus());
        }

        Console.WriteLine("\n Applying night mode to all devices...\n");

        foreach (iot_device device in devices)
        {
            device.ApplyMode("Night");
            Console.WriteLine(device.GetStatus());
        }

        Console.WriteLine("Smart_HomeConsole starting...");
        Console.WriteLine("Add device creation and hub actions once classes are implemented.");
    }
}

