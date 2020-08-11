using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkEventApiController : ControllerBase
    {
        private readonly ProtnoxDbContext context;
        private readonly IEventToSwitchMapping eventToSwitchMapping;

        public NetworkEventApiController(ProtnoxDbContext context, IEventToSwitchMapping eventToSwitchMapping)
        {
            this.context = context;
            this.eventToSwitchMapping = eventToSwitchMapping;
        }

        [HttpGet]
        public async Task<IEnumerable<Switch>> GetEvent()
        {
            var networkEvents = await context.NetworkEvents.ToListAsync();
            var switchList = eventToSwitchMapping.MapEventsToSwitches(networkEvents);
            return switchList;
        }
    }
}
