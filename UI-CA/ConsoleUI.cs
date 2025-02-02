using System.Diagnostics.CodeAnalysis;
using YearPlanner.BL;
using YearPlanner.BL.Domain;


namespace YearPlanner.UI.CA;


public class ConsoleUI
{
    private IManager _manager;
    public ConsoleUI(IManager manager)
    {
        _manager = manager;
    }
    public void Run()
    {
        int? input = WriteMenueAndReadInput();
        switch (input)
        {
            case 0:
                Console.WriteLine("Thank you for using my program, it will close now");
                return;
            case 1:
                DisplayPlanningForAllCustomers();
                break;
            case 2:
                DisplayPlanningForSearchedCustomer();
                break;
            case 3:
                AddNewCustomerToPlanning();
                break;
            case 4:
                AddNewTaskToCustomer();
                break;
        }

        Run();
    }
    
    private int? WriteMenueAndReadInput()
    {
        Console.WriteLine("What Would you like to do?"); 
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit"); 
        Console.WriteLine("1) Show planning for all customers"); 
        Console.WriteLine("2) Show planning for a certain customer"); 
        Console.WriteLine("3) Add a customer");
        Console.WriteLine("4) Add a task to a customer");
        Console.WriteLine("Choice (0-4):");
        try
        {
            int? input = int.Parse(Console.ReadLine()!);
            Console.WriteLine("");
            return input;
        }
        catch (Exception e)
        {
            Console.WriteLine("Not a valid input");
            return null;
        }
    }

    private void AddNewTaskToCustomer()
    {
        Console.WriteLine("Add Task to Company"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Company Name:");
        string companyName = Console.ReadLine();
        while (companyName == "" || companyName is null)
        {
            Console.WriteLine("Not a valid name");
            companyName = Console.ReadLine();
        }
        
        Console.WriteLine("Assignment name:");
        string assignmentName = Console.ReadLine();
        while (assignmentName == "" || assignmentName is null)
        {
            Console.WriteLine("Not a valid assignment name");
            assignmentName = Console.ReadLine();
        }
        
        Console.WriteLine("Assignment action date (YYYY-MM-DD):");
        string lineB = Console.ReadLine();
        DateTime assignmentActionDate;
        while (!DateTime.TryParseExact(lineB, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None,
                   out assignmentActionDate))
        {
            Console.WriteLine("Invalid date, please retry (format yyyy-MM-dd)");
            lineB = Console.ReadLine();
        }
        
        Console.WriteLine("Assignment description:");
        string assignmentDescription = Console.ReadLine();
        while (assignmentDescription == "" || assignmentDescription is null)
        {
            Console.WriteLine("Not a valid assignment description");
            assignmentDescription = Console.ReadLine();
        }
        
        _manager.AddTaskToCompany(companyName, assignmentName,assignmentActionDate ,assignmentDescription);
        //TODO Testing
        
    }

    private void AddNewCustomerToPlanning()
    {
        Console.WriteLine("Add Company"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Name:");
        string companyName = Console.ReadLine();
        while (companyName == "" || companyName is null)
        {
            Console.WriteLine("Not a valid name");
            companyName = Console.ReadLine();
        }
        
        _manager.AddCompany(companyName);
    }

    private void DisplayPlanningForSearchedCustomer()
    {
        Console.WriteLine("Search Company"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Company Name:");
        string companyName = Console.ReadLine();
        while (companyName == "" || companyName is null)
        {
            Console.WriteLine("Not a valid name, Try again");
            companyName = Console.ReadLine();
        }
        
        //Console.WriteLine(companyName);
        Company foundCompany = _manager.GetCompanyByName(companyName);
        Console.WriteLine("Planning for : " + foundCompany.CompanyName);
        DisplayCompanyInfo(foundCompany);
    }

    private void DisplayPlanningForAllCustomers()
    {
        ListOfCompanies listOfCompanies = _manager.GetAllCompanies();
        foreach (Company company in listOfCompanies.Companies)
        {
            DisplayCompanyInfo(company);
        }
    }

    private void DisplayBanner()
    {
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine(" Customer Name | January   | February  | March     | April     | May       | June      | July      | August    | September | October   | November  | December  | ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
    }

    private void DisplayCompanyInfo(Company company)
    {
        DisplayBanner();
        string[] months = new string[12];
        if (company.Assignments != null && company.Assignments.Count > 0)
        {
            foreach (Assignment assignment in company.Assignments)
            {
                int dueMonth = assignment.ActionDate.Month;
                months[dueMonth - 1] = "x";
            }
        }
            
        string customerName = company.CompanyName.PadRight(13); // Ensure the customer name is fixed-width
        string[] formattedMonths = months.Select(m => (m ?? "").PadLeft(9)).ToArray(); // Each column is 9 characters wide
        Console.WriteLine($" {customerName} | {string.Join(" | ", formattedMonths)} | ");

        if (company.Assignments != null && company.Assignments.Count > 0)
        {
            int count = 1;
            foreach (Assignment task in company.Assignments)
            {
                Console.WriteLine($"Task {count} Description: {task.AssignmentDescription}");
                count++;
            }

            Console.WriteLine();
        }
    }

}