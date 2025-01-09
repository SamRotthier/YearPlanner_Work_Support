
using System.Text.Json.Serialization;

namespace YearPlanner.BL.Domain;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    
    public ICollection<Assignment> Assignments { get; set; }
    


    [JsonConstructor]
    public Company(int CompanyId, string CompanyName, List<Assignment> Assignments)
    {
        this.CompanyId = CompanyId;
        this.CompanyName = CompanyName;
        this.Assignments = Assignments ?? new List<Assignment>();
    }
    
    /*
    public Company()
    {
        Assignments = new List<Assignment>();
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
    */
}
