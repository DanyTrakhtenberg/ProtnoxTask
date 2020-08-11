using System.Collections.Generic;

namespace Models
{
    public class Switch: IEventList
    {
        public string Switch_Ip { get; set; }
        public List<SwitchPort> PortList { get; set; }
        public List<int> EventList { get; set; }
        public Switch()
        {
            EventList = new List<int>();
            PortList = new List<SwitchPort>();
        }
    }
}
