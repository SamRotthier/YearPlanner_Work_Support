
namespace YearPlanner.BL.Domain;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    
    public ICollection<Assignment>? Assignments { get; set; }

    public Company(string companyName)
    {
        CompanyName = companyName;
    }

    public Company(string companyName, List<Assignment> assignments)
    {
        CompanyName = companyName;
        Assignments = assignments;
    }
}
