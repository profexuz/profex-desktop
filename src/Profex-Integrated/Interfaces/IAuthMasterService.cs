using Profex_Dtos.Auth;

namespace Profex_Integrated.Interfaces;

public interface IAuthMasterService
{
    public Task<bool> RegisterAsync(RegisterDto dto);
    public Task<bool> SendCodeForRegisterAsync(string phone);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(VerifyRegisterDto dtos);
    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);
}
