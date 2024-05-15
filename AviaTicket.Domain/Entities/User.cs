using AviaTicket.Domain.Commons;

namespace AviaTicket.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "User";
}
