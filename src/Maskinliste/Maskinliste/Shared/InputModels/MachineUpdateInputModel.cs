namespace Maskinliste.Shared.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class MachineUpdateInputModel
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public string Details { get; set; }
    }
}