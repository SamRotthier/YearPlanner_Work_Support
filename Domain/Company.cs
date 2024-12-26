
namespace YearPlanner.BL.Domain;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    
    public ICollection<Task>? Tasks { get; set; }

    public Company(string companyName)
    {
        CompanyName = companyName;
    }

    public Company(string companyName, List<Task> tasks)
    {
        CompanyName = companyName;
        Tasks = tasks;
    }
}
