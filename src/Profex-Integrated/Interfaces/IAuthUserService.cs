using Profex_Dtos.Auth;
using Profex_ViewModels.Vacancies;

namespace Profex_Integrated.Interfaces;

public interface IAuthUserService
{
    public Task<bool> RegisterAsync(RegisterDto dto);
    public Task<bool> SendCodeForRegisterAsync(string phone);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(VerifyRegisterDto dtos);
    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);
}
