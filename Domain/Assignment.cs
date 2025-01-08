namespace YearPlanner.BL.Domain;

public class Assignment
{
    public int AssignmentId { get; set; }
    public string AssignmentName { get; set; }
    public DateTime ActionDate { get; set; }
    public string AssignmentDescription { get; set; }
    

    public Assignment(string assignmentName)
    {
        AssignmentName = assignmentName;
    }

    public Assignment(string assignmentName, DateTime actionDate, string assignmentDescription)
    {
        AssignmentName = assignmentName;
        ActionDate = actionDate;
        AssignmentDescription = assignmentDescription;
    }
}