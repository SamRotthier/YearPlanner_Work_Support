using YearPlanner.BL.Domain;
using YearPlanner.DAL;

namespace YearPlanner.BL;

public class Manager : IManager
{
    private IRepository _repository;
    public Manager(IRepository repository)
    {
        _repository = repository;
        //InMemoryRepository.Seed();
        InMemoryRepository.SeedWithJson();
    }
    
    public ListOfCompanies GetAllCompanies()
    {
        return _repository.ReadAllCompanies();
    }

    public void AddCompany(string companyName)
    {
        Company company = new Company(companyName);
        _repository.createCompany(company);
    }

    public void AddTaskToCompany(string companyName, string assignmentName, DateTime actionDate, string assignmentDescription)
    {
        Assignment madeAssignment = new Assignment(assignmentName, actionDate, assignmentDescription);
        _repository.createTaskForCompany(companyName, madeAssignment);
    }

    public Company GetCompanyByName(string companyName)
    {
        return _repository.ReadCompanyByName(companyName);
    }
}