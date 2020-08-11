using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EventToSwitchMapping : IEventToSwitchMapping
    {
        public List<Switch> MapEventsToSwitches(IEnumerable<NetworkEvent> networkEvents)
        {
            Dictionary<string, Switch> switchIDSwitchDictionary = new Dictionary<string, Switch>();
            Dictionary<string, SwitchPort> switchPortIDSwitchPortDictionary = new Dictionary<string, SwitchPort>();
            Dictionary<string, Device> deviceIDSDeviceDictionary = new Dictionary<string, Device>();

            foreach (var networkEvent in networkEvents)
            {
                InsertIntoDictionary<Device>(networkEvent.Device_Mac, deviceIDSDeviceDictionary, out Device device, networkEvent.Event_id);
                device.Device_Mac = networkEvent.Device_Mac;
                InsertIntoDictionary<Switch>(networkEvent.Switch_Ip, switchIDSwitchDictionary, out Switch @switch, networkEvent.Event_id);
                @switch.Switch_Ip = networkEvent.Switch_Ip;
                string switchPortKey = networkEvent.Port_id.ToString() + networkEvent.Switch_Ip;
                var isPortExists = InsertIntoDictionary<SwitchPort>(switchPortKey, switchPortIDSwitchPortDictionary, out SwitchPort switchPort, networkEvent.Event_id);

                if (isPortExists == false)
                {
                    @switch.PortList.Add(switchPort);
                    switchPort.Port_id = networkEvent.Port_id;

                }
                switchPort.DeviceList.Add(device);
            }
            return switchIDSwitchDictionary.Values.ToList();
        }

        bool InsertIntoDictionary<T>(string key, Dictionary<string, T> dictionary, out T column, int eventId) where T : IEventList, new()
        {
            bool isExisted = false;
            if (dictionary.ContainsKey(key) == true)
            {
                column = dictionary[key];
                isExisted = true;
            }
            else
            {
                column = new T();
                dictionary.Add(key, column);
            }
            if (column.EventList.Any(e => e == eventId) == false)
            {
                column.EventList.Add(eventId);
            }
            return isExisted;

        }
    }
}
