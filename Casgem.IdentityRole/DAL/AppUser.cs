using Microsoft.AspNetCore.Identity;

namespace Casgem.IdentityRole.DAL
{
	public class AppUser : IdentityUser<int>
	{
        public string NameSurname { get; set; }
    }
}
