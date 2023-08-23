namespace Profex_Integrated.Interfaces;

public interface IIdentityService
{
    public long Id { get; set; }
    public string RoleName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
