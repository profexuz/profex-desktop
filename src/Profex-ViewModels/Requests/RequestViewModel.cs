namespace Profex_ViewModels.Requests;
public class RequestViewModel
{
    public long categoryId { get; set; }
    public long userId { get; set; }
    public string title { get; set; } = string.Empty;
    public double price { get; set; } = 0; // Narxi turining qarashli
    public string description { get; set; } = string.Empty;
    public string region { get; set; } = string.Empty;
    public string district { get; set; } = string.Empty;
    public double longitude { get; set; } = 0;
    public double latitude { get; set; } = 0;
    public string phoneNumber { get; set; } = string.Empty;
    public List<string> imagePath { get; set; } = new List<string>();
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public string categoryName { get; set; } = string.Empty;
    public List<string> images { get; set; } = new List<string>();
    public List<Request> request { get; set; } = new List<Request>();
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public long id { get; set; }
}
public class Request
{
    public long masterId { get; set; }
    public long postId { get; set; }
    public long userId { get; set; }
    public bool isAccepted { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public long id { get; set; }
}