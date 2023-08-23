using Profex_ViewModels.Users;

namespace Profex_Integrated.Interfaces;

public interface IUserService
{
    public Task<long> CountAsync();

    public Task<IList<User>> GetAllAsync();

}
