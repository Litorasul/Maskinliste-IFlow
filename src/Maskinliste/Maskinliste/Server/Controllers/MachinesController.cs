namespace Maskinliste.Server.Controllers
{
    
    using Maskinliste.Server.Services;
    using Maskinliste.Shared.ViewModels;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService service;

        public MachinesController(IMachineService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public ActionResult<List<MachineViewModel>> GetAll(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return this.BadRequest();
            }

            var machines = this.service.GetAllMachinesPerUser(userId);

            return machines;
        }

        [HttpGet("details")]
        public ActionResult<MachineDetailsViewModel> GetDetails(int machineId)
        {
            if (machineId <= 0)
            {
                return this.BadRequest();
            }

            var machine = this.service.GetMachineDetails(machineId);

            if (machine == null)
            {
                return this.NotFound();
            }

            return machine;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(string name, string details, string userId)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(userId))
            {
                return this.BadRequest();
            }

            var machineId = await this.service.CreateMachineAsync(name, details, userId);

            return machineId;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(int machineId, string name, string details)
        {
            if (machineId <= 0 || string.IsNullOrWhiteSpace(name))
            {
                return this.BadRequest();
            }

            var successfulUpdate = await this.service.UpdateMachineAsync(machineId, name, details);
            if (!successfulUpdate)
            {
                return this.NotFound();
            }

            return this.Ok();
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(int machineId)
        {
            if (machineId <= 0)
            {
                return this.BadRequest();
            }

            var successfulDelete = await this.service.DeleteMachineAsync(machineId);
            if (!successfulDelete)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}