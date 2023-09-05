using Newtonsoft.Json;
using Profex_Dtos.Masters;
using Profex_Integrated.Entities.Masters;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Security;
using Profex_Integrated.Services.Auth;
using Profex_ViewModels.Masters;

namespace Profex_Integrated.Services.Masters;

public class MasterService : IMasterService
{
    private AuthMasterService _masterAuth = new AuthMasterService();
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
                    var res = JsonConvert.DeserializeObject<IList<MasterViewModel>>(responseContent);
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
            using (HttpClient client = new HttpClient())
            {
                var token = IdentitySingelton.GetInstance().Token;
                var request = new HttpRequestMessage(HttpMethod.Put, API.UPDATE_MASTERS + $"/{id}");
                request.Headers.Add("Authorization", $"Bearer {token}");
                using (var content = new MultipartFormDataContent())
                {

                    content.Add(new StringContent(dto.FirstName), "FirstName");
                    content.Add(new StringContent(dto.LastName), "LastName");
                    content.Add(new StringContent(dto.PhoneNumber), "PhoneNumber");
                    content.Add(new StringContent(dto.IsFree.ToString()), "IsFree");
                    content.Add(new StreamContent(File.OpenRead(dto.ImagePath)), "ImagePath", dto.ImagePath);
                    request.Content = content;

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            return false;
        }
    }
}
