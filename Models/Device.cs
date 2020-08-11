using System;
using System.Collections.Generic;

namespace Models
{

    public class Device: IEventList
    {
        public string Device_Mac { get; set; }
        public List<int> EventList { get; set; }
        public Device()
        {
            EventList = new List<int>();
        }
    }
}
