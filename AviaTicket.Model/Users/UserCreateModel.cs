namespace AviaTicket.Model.Users;

public class UserCreateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "User";
}
