namespace Profex_ViewModels.Categories;

public class CategoryViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public  DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;}

}
