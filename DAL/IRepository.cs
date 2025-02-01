using YearPlanner.BL.Domain;

namespace YearPlanner.DAL;

public interface IRepository
{
    ListOfCompanies ReadAllCompanies();
    void createCompany(Company company);
    void createTaskForCompany(string companyName, Assignment assignment);
    Company ReadCompanyByName(string companyName);
}