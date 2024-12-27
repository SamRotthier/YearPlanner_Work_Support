namespace YearPlanner.BL.Domain;

public class Assignment
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public DateTime ActionDate { get; set; }
    public string TaskDescription { get; set; }
    

    public Assignment(string taskName)
    {
        TaskName = taskName;
    }

    public Assignment(string taskName, DateTime actionDate, string taskDescription)
    {
        TaskName = taskName;
        ActionDate = actionDate;
        TaskDescription = taskDescription;
    }
}