using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace TaskStates.Models
{
    public class UserModel : IdentityUser
    {
        public string DisplayName { get; set; } 
    }
}
