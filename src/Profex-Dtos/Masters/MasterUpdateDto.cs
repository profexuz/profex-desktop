using Microsoft.AspNetCore.Http;

namespace Profex_Dtos.Masters;

public class MasterUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = default!;
    public bool IsFree { get; set; }
}
