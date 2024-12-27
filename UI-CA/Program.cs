


using YearPlanner.BL;
using YearPlanner.DAL;
using YearPlanner.UI.CA;

IRepository repository = new InMemoryRepository();
IManager manager = new Manager(repository);

ConsoleUI consoleUi = new ConsoleUI();
consoleUi.Run();


