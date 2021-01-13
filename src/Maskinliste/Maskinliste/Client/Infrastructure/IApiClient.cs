namespace Maskinliste.Client.Infrastructure
{
    using Maskinliste.Shared.ViewModels;
    using Maskinliste.Shared.InputModels;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiClient
    {
        /// <summary>
        /// Get all Machines created by certain User.
        /// </summary>
        /// <param name="userId">The Id of the User.</param>
        /// <returns>List of Machine View Models</returns>
        Task<IList<MachineViewModel>> GetAllMachinesPerUserAsync(string userId);

        /// <summary>
        /// Get all the details for a certain Machine.
        /// </summary>
        /// <param name="machineId">The Id of the Machine</param>
        /// <returns>The details as a MachineDetailsViewModel</returns>
        Task<MachineDetailsViewModel> GetMachineDetailsAsync(int machineId);

        /// <summary>
        /// Create a New Machine.
        /// </summary>
        /// <param name="model">Input from the Create Form.</param>
        /// <returns>The Id of the newly created Machine.</returns>
        Task<int> CreateMachineAsync(MachineCreateInputModel model);

        /// <summary>
        /// Update a Machine, that already exists. 
        /// </summary>
        /// <param name="model">Input from the Update Form.</param>
        Task UpdateMachineAsync(MachineUpdateInputModel model);

        /// <summary>
        /// Delete a Machine.
        /// </summary>
        /// <param name="machineId">The Id of the Machine.</param>
        Task DeleteMachineAsync(int machineId);
    }
}