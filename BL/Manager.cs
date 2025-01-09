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
    
    public List<Company> GetAllCompanies()
    {
        return _repository.ReadAllCompanies();
    }
}