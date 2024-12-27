
namespace YearPlanner.BL.Domain;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    
    public ICollection<Assignment>? Tasks { get; set; }

    public Company(string companyName)
    {
        CompanyName = companyName;
    }

    public Company(string companyName, List<Assignment> tasks)
    {
        CompanyName = companyName;
        Tasks = tasks;
    }
}
