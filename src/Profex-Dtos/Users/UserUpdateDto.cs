using Microsoft.AspNetCore.Http;

namespace Profex_Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    //public IFormFile? ImagePath { get; set; }
    public IFormFile ImagePath { get; set; } // Rasmlarni qabul qilish uchun IFormFile ishlatamiz
    public bool IsFree { get; set; }
}
