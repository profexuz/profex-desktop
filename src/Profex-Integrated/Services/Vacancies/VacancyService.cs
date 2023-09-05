using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Vacancies;

namespace Profex_Integrated.Services.Vacancies;

public class VacancyService : IVacancyService
{
    public async Task<IList<Vacancy>> GetAllAsync(int page)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(API.GETALL_VACANCY);
                var result = await client.GetAsync($"{client.BaseAddress}?/page={page}");

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

    public async Task<IList<Vacancy>> GetByIdAsync(long id)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API.GETBYID_VACANCY);
                var response = await client.GetAsync($"{client.BaseAddress}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var vacancy = JsonConvert.DeserializeObject<IList<Vacancy>>(responseContent);
                    return vacancy;
                }
                else
                {
                    // Agar javob yaxshi kelmasa, bo'sh obyektni qaytarish
                    return new List<Vacancy>();
                }
            }
        }
        catch
        {
            // Xato yuzaga kelsa, hammasini o'zgartirishsiz
            return new List<Vacancy>();
        }
    }

    public Task<IList<Vacancy>> SearchAsync(string search)
    {
        throw new NotImplementedException();
    }
}
