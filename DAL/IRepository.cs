using YearPlanner.BL.Domain;

namespace YearPlanner.DAL;

public interface IRepository
{
    ListOfCompanies ReadAllCompanies();
}