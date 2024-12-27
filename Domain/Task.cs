namespace YearPlanner.BL.Domain;

public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public DateTime ActionDate { get; set; }
    public string TaskDescription { get; set; }
    

    public Task(string taskName)
    {
        TaskName = taskName;
    }

    public Task(string taskName, DateTime actionDate, string taskDescription)
    {
        TaskName = taskName;
        ActionDate = actionDate;
        TaskDescription = taskDescription;
    }
}