using Profex_Dtos.Masters;
using Profex_Integrated.Entities.Masters;
using Profex_ViewModels.Masters;

namespace Profex_Integrated.Interfaces;

public interface IMasterService
{
    public Task<IList<MasterSkill>> SortBySkillId(long skillId);
    public Task<IList<MasterViewModel>> SearchAsync(string search);
    public Task<IList<MasterViewModel>> GetAllAsync();
    public Task<MasterViewModel> GetByIdAsync(long id);
    public Task<bool> UpdateAsync(long id, MasterUpdateDto dto);
}
