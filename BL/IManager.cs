using YearPlanner.BL.Domain;

namespace YearPlanner.BL;

public interface IManager
{
    ListOfCompanies GetAllCompanies();
    void AddCompany(string companyName);
    void AddTaskToCompany(string companyName, string assignmentName, DateTime actionDate, string assignmentDescription);
    Company GetCompanyByName(string companyName);
    
    
}