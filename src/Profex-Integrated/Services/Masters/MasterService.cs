using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profex_Dtos.Masters;
using Profex_Integrated.Entities.Masters;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Masters;
using System.Numerics;
using System.Text;

namespace Profex_Integrated.Services.Masters;

public class MasterService : IMasterService
{
    public async Task<IList<MasterViewModel>> GetAllAsync()
    {

        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(API.GETALL_MASTERS);
                var result = await client.GetAsync(client.BaseAddress);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    var res =  JsonConvert.DeserializeObject<IList<MasterViewModel>>(responseContent);
                    return res;
                }
                else
                {
                    return new List<MasterViewModel>();
                }
            }
            catch
            {
                return new List<MasterViewModel>();

            }
        }
    }

    public async Task<MasterViewModel> GetByIdAsync(long id)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API.GETBYID_MASTERS);
                var response = await client.GetAsync($"{client.BaseAddress}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var masterViewModel = JsonConvert.DeserializeObject<MasterViewModel>(responseContent);
                    return masterViewModel;
                }
                else
                {
                    // Agar javob yaxshi kelmasa, bo'sh obyektni qaytarish
                    return new MasterViewModel();
                }
            }
        }
        catch
        {
            // Xato yuzaga kelsa, hammasini o'zgartirishsiz
            return new MasterViewModel();
        }
    }

    public Task<IList<MasterViewModel>> SearchAsync(string search)
    {
        throw new NotImplementedException();
    }

    public Task<IList<MasterSkill>> SortBySkillId(long skillId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long id, MasterUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
