using System.Threading.Tasks;
using EY.CabinCrew.Core;
using EY.CabinCrew.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EY.CabinCrew.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RosterController : ControllerBase
    {
        private readonly ILogger<RosterController> logger;
        private readonly IRepository<Roster> repository;
        public RosterController(ILogger<RosterController> logger, IRepository<Roster> repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<Roster> Get([FromQuery] string employeeId)
        {
            Roster roster = await repository.Find(r => r.EmpId == employeeId);
            return roster;
        }







    }
}