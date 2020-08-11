using System.Collections.Generic;

namespace Models
{
    public class SwitchPort: IEventList
    {
        public int Port_id { get; set; }
        public List<Device> DeviceList { get; set; }
        public List<int> EventList { get; set; }

        public SwitchPort()
        {
            DeviceList = new List<Device>() ;
            EventList = new List<int>();
        }
    }
}
