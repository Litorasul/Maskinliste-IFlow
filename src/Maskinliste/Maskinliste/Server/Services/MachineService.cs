namespace Maskinliste.Server.Services
{
    using Maskinliste.Server.Data;
    using Maskinliste.Shared.ViewModels;
    using Maskinliste.Server.Models;

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

        public List<MachineViewModel> GetAllMachinesPerUser(string userName)
        {
            return this.dbContext
                .Machines
                .Where(x => x.ApplicationUser.UserName == userName)
                .Select(x => new MachineViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public MachineDetailsViewModel GetMachineDetails(int machineId)
        {
            return this.dbContext
                .Machines
                .Where(x => x.Id == machineId)
                .Select(x => new MachineDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details
                })
                .FirstOrDefault();
        }

        public async Task<int> CreateMachineAsync(string name, string details, string userName)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            var machine = new Machine
            {
                Name = name,
                Details = details,
                ApplicationUserId = user.Id
            };

            await this.dbContext.Machines.AddAsync(machine);
            await this.dbContext.SaveChangesAsync();

            return machine.Id;
        }

        public async Task<bool> UpdateMachineAsync(int machineId, string name, string details)
        {
            var machine = await this.dbContext
                .Machines
                .FirstOrDefaultAsync(x => x.Id == machineId);

            if (machine != null)
            {
                machine.Name = name;
                machine.Details = details;
            }
            else
            {
                return false;
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteMachineAsync(int machineId)
        {
            var machine = await this.dbContext
                .Machines
                .FirstOrDefaultAsync(x => x.Id == machineId);

            if (machine != null)
            {
                this.dbContext.Machines.Remove(machine);
            }
            else
            {
                return false;
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}