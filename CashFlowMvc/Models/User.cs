using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CashFlowMvc.Models
{
    public class User : IdentityUser <Guid>
    {
        [Required]
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    }
}
