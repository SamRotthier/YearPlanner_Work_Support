
using System.Text.Json.Serialization;

namespace YearPlanner.BL.Domain;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    
    public ICollection<Assignment> Assignments { get; set; }
    
    public Company(int companyId, string companyName, List<Assignment> assignments)
    {
        this.CompanyId = companyId;
        this.CompanyName = companyName;
        this.Assignments = assignments ?? new List<Assignment>();
    }
    
    
    public Company()
    {
        
    }

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
