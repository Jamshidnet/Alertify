using Microsoft.AspNetCore.Identity;

namespace Alertify.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int OrganizationId { get; set; }
}
