using YearPlanner.BL.Domain;

namespace YearPlanner.BL;

public interface IManager
{
    ListOfCompanies GetAllCompanies();
    void AddCompany(string companyName);
    
}