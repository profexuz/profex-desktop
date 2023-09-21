namespace Profex_Dtos.Post;

public class PostCreateDto
{
    public  long CategoryId { get; set; }
    public string Title { get; set; } = String.Empty;
    public double Price { get; set; }
    public string Deccription { get; set; } = String.Empty;
    public string Region { get; set; } = String.Empty;
    public string District { get; set; } = String.Empty;
    public double Latidute { get; set; }
    public double Longitude { get; set;}
    public string PhoneNumber { get; set; } = String.Empty;
}
