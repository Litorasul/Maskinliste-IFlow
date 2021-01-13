namespace Maskinliste.Shared.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class MachineCreateInputModel
    {
        [Required] 
        public string Name { get; set; }

        public string Details { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}