namespace Profex_ViewModels.Masters;

public class MasterViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public bool IsFree { get; set; }

    public List<SkillMaster> MasterSkills { get; set; } = new List<SkillMaster>();
    public class SkillMaster
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
    }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
