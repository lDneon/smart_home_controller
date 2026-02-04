using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_HomeLib
{
    public class SecurityCam : iot_device
    {
        private bool is_recording;
        public SecurityCam(string deviceid, string name) : base(deviceid, name)
        {
            is_recording = false;
        }
        public void StartRecording()
        {
            if (!IsPoweredOn)
                throw new InvalidOperationException("Security camera must be powered on to start recording.");
            is_recording = true;
        }
        public void StopRecording()
        {
            is_recording = false;
        }
        public override string GetStatus()
        {
            return $"Security Camera '{Name}' (ID: {DeviceId}) - Online: {IsOnline}, Powered On: {IsPoweredOn}, Recording: {is_recording}";
        }
        public override void ApplyMode(string mode)
        {
            // if (mode == "Away" && IsPoweredOn)
            //{ StartRecording();}
           // else if (mode == "Home" && IsPoweredOn)  {StopRecording();}

            if (mode == "Night")
            {
                if (!IsPoweredOn) 
                {
                    StartRecording();
                }
            }
           
        }
    }
}
