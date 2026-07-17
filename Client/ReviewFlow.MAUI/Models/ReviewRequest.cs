namespace ReviewFlow.MAUI.Models;

public class ReviewRequest
{
    public int Id { get; set; }
    public string StudentName { get; set; } = "";
    public string FacultyName { get; set; } = "";
    public string ProjectTitle { get; set; } = "";
    public string Status { get; set; } = "";
}