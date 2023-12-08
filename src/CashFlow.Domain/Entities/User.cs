using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Entities
{
    public class User : IdentityUser <Guid>
    {
        [Required]
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    }
}
