using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Masters;
using Profex_ViewModels.Vacancies;

namespace Profex_Integrated.Services.Vacancies;

public class VacancyService : IVacancyService
{
    public async Task<IList<Vacancy>> GetAllAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(API.GETALL_VACANCY);
                var result = await client.GetAsync(client.BaseAddress);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<IList<Vacancy>>(responseContent);
                    return res;
                }
                else
                {
                    return new List<Vacancy>();
                }
            }
            catch
            {
                return new List<Vacancy>();

            }
        }
    }

    public Task<Vacancy> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Vacancy>> SearchAsync(string search)
    {
        throw new NotImplementedException();
    }
}
