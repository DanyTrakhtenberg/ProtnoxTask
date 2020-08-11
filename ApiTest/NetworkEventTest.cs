using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace ApiTest
{
    [TestClass]
    public class NetworkEventTest
    {
        [TestMethod]
        public async Task  TestMethod1()
        {
            var options = new DbContextOptionsBuilder<ProtnoxDbContext>()
          .UseInMemoryDatabase(databaseName: "ProtnoxDb")
          .Options;

            using (var context = new ProtnoxDbContext(options))
            {
                context.NetworkEvents.Add(new NetworkEvent() { Event_id = 1001, Switch_Ip = "1.1.1.1", Device_Mac = "AABBCC000001", Port_id = 12 });
                context.NetworkEvents.Add(new NetworkEvent() { Event_id = 1002, Switch_Ip = "1.1.1.1", Device_Mac = "AABBCC000009", Port_id = 11 });
                context.NetworkEvents.Add(new NetworkEvent() { Event_id = 1003, Switch_Ip = "192.168.1.1", Device_Mac = "NULL", Port_id = 48 });
                context.NetworkEvents.Add(new NetworkEvent() { Event_id = 1004, Switch_Ip = "1.1.1.1", Device_Mac = "NULL", Port_id = 12 });
                context.NetworkEvents.Add(new NetworkEvent() { Event_id = 1005, Switch_Ip = "192.168.1.1", Device_Mac = "AABBCC000001", Port_id = 47 });
                context.SaveChanges();
            }

            using (var context = new ProtnoxDbContext(options))
            {
                NetworkEventApiController networkEventApiController = new NetworkEventApiController(context, new EventToSwitchMapping());
                var results = await networkEventApiController.GetEvent();
                var resultList = results.ToList();
                Assert.AreEqual(resultList.Count, 2);
            }

        }
    }
}
