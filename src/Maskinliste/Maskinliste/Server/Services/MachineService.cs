namespace Maskinliste.Server.Services
{
    using Maskinliste.Server.Data;
    using Maskinliste.Shared.ViewModels;
    using Maskinliste.Server.Models;
    using Maskinliste.Shared.Mapping;

    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    public class MachineService : IMachineService
    {
        private readonly ApplicationDbContext dbContext;

        public MachineService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MachineViewModel> GetAllMachinesPerUser(string userId)
        {
            return this.dbContext
                .Machines
                .Where(x => x.ApplicationUserId == userId)
                .To<MachineViewModel>()
                .ToList();
        }

        public MachineDetailsViewModel GetMachineDetails(int machineId)
        {
            return this.dbContext
                .Machines
                .Where(x => x.Id == machineId)
                .To<MachineDetailsViewModel>()
                .FirstOrDefault();
        }

        public async Task<int> CreateMachineAsync(string name, string details, string userId)
        {
            var machine = new Machine
            {
                Name = name,
                Details = details,
                ApplicationUserId = userId
            };

            await this.dbContext.Machines.AddAsync(machine);
            await this.dbContext.SaveChangesAsync();

            return machine.Id;
        }

        public async Task UpdateMachineAsync(int machineId, string name, string details)
        {
            var machine = await this.dbContext
                .Machines
                .FirstOrDefaultAsync(x => x.Id == machineId);

            if (machine != null)
            {
                machine.Name = name;
                machine.Details = details;
            }

            await this.dbContext.SaveChangesAsync();
        }
        public async Task DeleteMachineAsync(int machineId)
        {
            var machine = await this.dbContext
                .Machines
                .FirstOrDefaultAsync(x => x.Id == machineId);

            if (machine != null)
            {
                this.dbContext.Machines.Remove(machine);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}