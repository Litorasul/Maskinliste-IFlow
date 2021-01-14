namespace Maskinliste.Client.Infrastructure
{
    using Maskinliste.Shared.ViewModels;
    using Maskinliste.Shared.InputModels;

    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IList<MachineViewModel>> GetAllMachinesPerUserAsync(string userName)
        {
            var machines = await this.httpClient
                .GetFromJsonAsync<IList<MachineViewModel>>($"/api/Machines/all?userName={userName}");
            return machines;
        }

        public async Task<MachineDetailsViewModel> GetMachineDetailsAsync(int machineId)
        {
            var machine =
                await this.httpClient.GetFromJsonAsync<MachineDetailsViewModel>(
                    $"/api/Machines/details?machineId={machineId}");
            return machine;
        }

        public async Task<int> CreateMachineAsync(MachineCreateInputModel model)
        {
            var response = await this.httpClient
                .PostAsJsonAsync("/api/Machines/create", model);

            var id = await response.Content.ReadFromJsonAsync<int>();
            return id;
        }

        public async Task UpdateMachineAsync(MachineUpdateInputModel model)
        {
            await this.httpClient
                .PostAsJsonAsync("/api/Machines/update", model);
        }

        public async Task DeleteMachineAsync(int machineId)
        {
            await this.httpClient
                .PostAsJsonAsync("/api/Machines/delete", machineId);
        }
    }
}