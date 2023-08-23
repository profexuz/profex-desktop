using Profex_ViewModels.Vacancies;

namespace Profex_Integrated.Interfaces;

public interface IVacancyService
{
    public Task<IList<Vacancy>> GetAllAsync();

    public Task<Vacancy> GetByIdAsync(long id);

    public Task<IList<Vacancy>> SearchAsync(string search);
}
