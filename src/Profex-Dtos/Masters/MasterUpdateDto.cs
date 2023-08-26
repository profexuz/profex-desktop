using Microsoft.AspNetCore.Http;

namespace Profex_Dtos.Masters;

public class MasterUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    //public string PhoneNumberConfirmed { get; set; } = string.Empty;
    public string ImagePath { get; set; } = default!;
    //public string PasswordHash { get; set; } = string.Empty;
    //public string Salt { get; set; } = string.Empty;
    public bool IsFree { get; set; }
}
