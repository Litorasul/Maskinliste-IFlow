namespace Maskinliste.Shared.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class MachineDetailsViewModel
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public string Details { get; set; }
    }
}