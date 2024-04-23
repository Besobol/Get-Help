using Microsoft.AspNetCore.Identity;

namespace Get_Help.Infrastructure.Data.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }
    }
}
