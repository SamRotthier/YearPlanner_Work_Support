using System.Diagnostics.CodeAnalysis;

namespace YearPlanner.UI.CA;


public class ConsoleUI
{
    
    public ConsoleUI()
    {
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
        throw new NotImplementedException();
    }

    private void AddNewCustomerToPlanning()
    {
        throw new NotImplementedException();
    }

    private void DisplayPlanningForSearchedCustomer()
    {
        throw new NotImplementedException();
    }

    private void DisplayPlanningForAllCustomers()
    {
        throw new NotImplementedException();
    }


}