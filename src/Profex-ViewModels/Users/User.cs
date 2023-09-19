using System.Security.Principal;

namespace Profex_ViewModels.Users;

public class User
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public string PhoneNumberConfirmed { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public  DateTime CreatedAt { get; set; }
    public  DateTime UpdatedAt { get; set; }

}
