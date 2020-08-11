using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IEventToSwitchMapping
    {
        List<Switch> MapEventsToSwitches(IEnumerable<NetworkEvent> networkEvents);
    }
}