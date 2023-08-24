using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profex_Dtos.Auth;
using Profex_Dtos.Masters;
using Profex_Integrated.Entities.Masters;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Masters;
using System.ComponentModel.DataAnnotations;
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

    public async Task<IList<MasterViewModel>> SearchAsync(string search)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API.SEARCH_MASTERS);
                var response = await client.GetAsync($"{client.BaseAddress}?search={search}&page=1");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var masterViewModel = JsonConvert.DeserializeObject<IList<MasterViewModel>>(responseContent);
                    return masterViewModel!;
                }
                else
                {
                    // Agar javob yaxshi kelmasa, bo'sh obyektni qaytarish
                    return new List<MasterViewModel>();
                }
            }
        }
        catch
        {
            // Xato yuzaga kelsa, hammasini o'zgartirishsiz
            return new List<MasterViewModel>();
        }
    }

    public Task<IList<MasterSkill>> SortBySkillId(long skillId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(long id, MasterUpdateDto dto)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.UPDATE_MASTERS);

            using (var formData = new MultipartFormDataContent())
            {
                StringContent Id = new StringContent(id.ToString());
                StringContent FirstName = new StringContent(dto.FirstName.ToString());
                StringContent LastName = new StringContent(dto.LastName.ToString());
                StringContent Number = new StringContent(dto.PhoneNumber.ToString());
                StringContent ImagePath = new StringContent(dto.ImagePath.ToString());
                StringContent IsFree = new StringContent(dto.IsFree.ToString());
                // Try as I might C# adds a CrLf to the end of the job_id tag - so have to strip it in ruby
                formData.Add(Id, "Id");
                formData.Add(FirstName, "FirstName");
                formData.Add(LastName, "LastName");
                formData.Add(Number, "PhoneNumber");
                formData.Add(ImagePath, "ImagePath");
                formData.Add(IsFree, "IsFree");
                var result = await client.PostAsync($"{client.BaseAddress}/{id}", formData);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public Task UpdateAsync(long id, MasterViewModel masterViewModel)
    {
        throw new NotImplementedException();
    }
}
