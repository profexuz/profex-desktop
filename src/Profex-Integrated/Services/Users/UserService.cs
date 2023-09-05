using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Users;

namespace Profex_Integrated.Services.Users;

public class UserService : IUserService
{
    public async Task<long> CountAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(API.COUNT_USERS);
                var result = await client.GetAsync(client.BaseAddress);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<long>(responseContent);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;

            }
        }
    }

    public async Task<IList<User>> GetAllAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(API.GETALL_USERS);
                var result = await client.GetAsync(client.BaseAddress);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<User>>(responseContent);
                }
                else
                {
                    return new List<User>();
                }
            }
            catch
            {
                return new List<User>();

            }
        }
    }

    public async Task<User> GetByIdAsync(long id)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API.GETBYID_USERS);
                var response = await client.GetAsync($"{client.BaseAddress}?userId={id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var masterViewModel = JsonConvert.DeserializeObject<User>(responseContent);
                    return masterViewModel;
                }
                else
                {
                    // Agar javob yaxshi kelmasa, bo'sh obyektni qaytarish
                    return new User();
                }
            }
        }
        catch
        {
            // Xato yuzaga kelsa, hammasini o'zgartirishsiz
            return new User();
        }
    }
}
