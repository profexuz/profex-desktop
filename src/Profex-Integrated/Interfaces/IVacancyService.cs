using Profex_ViewModels.Vacancies;

namespace Profex_Integrated.Interfaces;

public interface IVacancyService
{
    public Task<IList<Vacancy>> GetAllAsync(int page);

    public Task<IList<Vacancy>> GetByIdAsync(long id);

    public Task<IList<Vacancy>> SearchAsync(string search);
}
