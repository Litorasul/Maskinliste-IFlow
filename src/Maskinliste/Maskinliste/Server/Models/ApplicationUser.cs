namespace Maskinliste.Server.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
