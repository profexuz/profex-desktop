namespace Profex_ViewModels.Skills;

public class SkillViewModel
{
    public  int Id { get; set; }
    public  int CategoryId { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
    public  DateTime UpdatedAt { get; set; }

}
