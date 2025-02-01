using System.Text.Json;
using YearPlanner.BL.Domain;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace YearPlanner.DAL;

public class InMemoryRepository: IRepository
{
    private static ListOfCompanies _listOfCompanies = new ListOfCompanies();
    
    public static void Seed()
    {
        //generate test data
        
        //Customer1
        Assignment task1C1 = new Assignment("Updates", new DateTime(2024,02,11), "Updates to the system");
        Assignment task2C1 = new Assignment("Cleaning", new DateTime(2024,05,11), "Cleaning of the system");
        List<Assignment> tasksC1 = new List<Assignment>();
        tasksC1.Add(task1C1);
        tasksC1.Add(task2C1);
        Company customer1 = new Company("Customer1", tasksC1);
        _listOfCompanies.Companies.Add(customer1);
        
        //Customer2
        Assignment task1C2 = new Assignment("Certificates", new DateTime(2024,11,11), "Certificates renewal");
        Assignment task2C2 = new Assignment("tests", new DateTime(2024,01,11), "General tests");
        Assignment task3C2 = new Assignment("Updates", new DateTime(2024,02,11), "Updates to the system");
        List<Assignment> tasksC2 = new List<Assignment>();
        tasksC2.Add(task1C2);
        tasksC2.Add(task2C2);
        tasksC2.Add(task3C2);
        Company customer2 = new Company("Customer2", tasksC2);
        _listOfCompanies.Companies.Add(customer2);
    }

    
    public static void SeedWithJson()
    {
        string jsonString  = File.ReadAllText("ExampleJson.json");
        try
        {
            _listOfCompanies = JsonSerializer.Deserialize<ListOfCompanies>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deserialization failed: {ex.Message}");
        }
    }

    
    public ListOfCompanies ReadAllCompanies()
    {
        return _listOfCompanies;
    }

    public void createCompany(Company company)
    {
        _listOfCompanies.Companies.Add(company);
        Console.WriteLine("Name of newly added company to the list: " + _listOfCompanies.Companies.Last().CompanyName);
    }

    public void createTaskForCompany(string companyName, Assignment assignment)
    {
        _listOfCompanies.Companies.FirstOrDefault(x => x.CompanyName == companyName).Assignments.Add(assignment);
    }

    public Company ReadCompanyByName(string companyName)
    {
        try
        {
            Company companyByName = _listOfCompanies.Companies.FirstOrDefault(x => x.CompanyName == companyName) ?? throw new Exception();
            return companyByName;
        }
        catch (Exception e)
        { //TODO
            Console.WriteLine("Company could not be found");
            throw;
        }
    }
}