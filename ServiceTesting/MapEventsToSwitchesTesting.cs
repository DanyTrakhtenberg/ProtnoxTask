using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTesting
{
    [TestClass]
    public class MapEventsToSwitchesTesting
    {

        [TestMethod]
        public void MapEventsToSwitches_oneIp_SwitchList()
        {
            NetworkEvent[] events = new NetworkEvent[] {
            new NetworkEvent() { Event_id= 1001, Switch_Ip= "1.1.1.1",Device_Mac = "AABBCC000001", Port_id =12 },
            new NetworkEvent() { Event_id= 1001, Switch_Ip= "1.1.1.1",Device_Mac = "AABBCC000009", Port_id =11 },
            new NetworkEvent() { Event_id = 1003, Switch_Ip = "192.168.1.1", Device_Mac = "NULL", Port_id = 48 },
            new NetworkEvent() { Event_id = 1002, Switch_Ip = "1.1.1.1", Device_Mac = "NULL", Port_id = 12 },
            new NetworkEvent() { Event_id = 1001, Switch_Ip = "192.168.1.1", Device_Mac = "AABBCC000001", Port_id = 47 }
           };
            EventToSwitchMapping sut = new EventToSwitchMapping();
            var result = sut.MapEventsToSwitches(events);
            var @switch = result.FirstOrDefault(e => e.Switch_Ip == "1.1.1.1");
            Assert.AreEqual(@switch.EventList.Count, 2);
            Assert.AreEqual(@switch.PortList.Count, 2);
            var port = @switch.PortList.FirstOrDefault(e => e.Port_id == 12);
            Assert.AreEqual(port.DeviceList.Count, 2);
            var device = port.DeviceList.FirstOrDefault(e => e.Device_Mac == "AABBCC000001");
            Assert.AreEqual(device.EventList.Count, 1);
        }
    }
}
