using System.Text.Json;
using YearPlanner.BL.Domain;



namespace YearPlanner.DAL;

public class InMemoryRepository: IRepository
{
    private static List<Company> _companies = new List<Company>();
    /*
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
        _companies.Add(customer1);
        
        //Customer2
        Assignment task1C2 = new Assignment("Certificates", new DateTime(2024,11,11), "Certificates renewal");
        Assignment task2C2 = new Assignment("tests", new DateTime(2024,01,11), "General tests");
        Assignment task3C2 = new Assignment("Updates", new DateTime(2024,02,11), "Updates to the system");
        List<Assignment> tasksC2 = new List<Assignment>();
        tasksC2.Add(task1C2);
        tasksC2.Add(task2C2);
        tasksC2.Add(task3C2);
        Company customer2 = new Company("Customer2", tasksC2);
        _companies.Add(customer2);
    }
    */
    
    public static void SeedWithJson()
    {
        string jsonString  = File.ReadAllText("ExampleJson2.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Allow camelCase in JSON
            IncludeFields = true, // Enable field matching
            WriteIndented = true               // For debugging
        };
        Console.WriteLine(jsonString);
        try
        {
            _companies = JsonSerializer.Deserialize<List<Company>>(jsonString, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deserialization failed: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    
    public List<Company> ReadAllCompanies()
    {
        return _companies;
    }

}