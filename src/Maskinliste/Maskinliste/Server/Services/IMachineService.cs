namespace Maskinliste.Server.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Maskinliste.Shared.ViewModels;

    public interface IMachineService
    {
        /// <summary>
        /// Get all Machines created by certain User.
        /// </summary>
        /// <param name="userId">The Id of the User.</param>
        /// <returns>List of Machine View Models</returns>
        List<MachineViewModel> GetAllMachinesPerUser(string userId);

        /// <summary>
        /// Get all the details for a certain Machine.
        /// </summary>
        /// <param name="machineId">The Id of the Machine</param>
        /// <returns>The details as a MachineDetailsViewModel</returns>
        MachineDetailsViewModel GetMachineDetails(int machineId);

       /// <summary>
       /// Create a New Machine.
       /// </summary>
       /// <param name="name">The Name of the Machine</param>
       /// <param name="details">The Details for the Machine.</param>
       /// <param name="userId">The Id of the User who creates the Machine.</param>
       /// <returns>The Id of the newly created Machine.</returns>
        Task<int> CreateMachineAsync(string name, string details, string userId);

       /// <summary>
       /// Update a Machine, that already exists. 
       /// </summary>
       /// <param name="machineId">The Id of the Machine.</param>
       /// <param name="name">The New name for the Machine.</param>
       /// <param name="details">The New details for the Machine.</param>
       /// <returns>If Update was successful.</returns>
       Task<bool> UpdateMachineAsync(int machineId, string name, string details);

       /// <summary>
       /// Delete a Machine.
       /// </summary>
       /// <param name="machineId">The Id of the Machine.</param>
       /// <returns>If Delete was successful.</returns>
       Task<bool> DeleteMachineAsync(int machineId);
    }
}