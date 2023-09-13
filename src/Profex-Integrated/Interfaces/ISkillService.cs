using Profex_ViewModels.Categories;
using Profex_ViewModels.Skills;

namespace Profex_Integrated.Interfaces;

public interface ISkillService
{
    public Task<IList<CategoryViewModel>> GetAllAysnc(long page);
    public Task<IList<SkillViewModel>> GetByCategoryId(long categoryId,long page);
    public Task<IList<SkillViewModel>> GetById(long id);
}
