namespace Maskinliste.Shared.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class MachineViewModel
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}