using ReviewFlow.MAUI.Services;
using System.Collections.ObjectModel;
namespace ReviewFlow.MAUI;

public partial class MainPage : ContentPage
{
    private readonly ApiService _api = new();
    private ObservableCollection<string> Logs = new();
    public MainPage()
    {
        InitializeComponent();

        LogCollection.ItemsSource = Logs;
    }

    private void AddLog(string message)
    {
        Logs.Insert(
            0,
            $"[{DateTime.Now:HH:mm:ss}] {message}"
        );
    }

    private async void GetReviewClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(ReviewIdEntry.Text, out int id))
        {
            AddLog("Please enter a valid Review ID.");
            return;
        }

        try
        {
            AddLog($"GET /api/Review/{id}");

            var review = await _api.GetReviewById(id);

            if (review == null)
            {
                AddLog("Review not found.");
                StudentLabel.Text = "Student : -";
                FacultyLabel.Text = "Faculty : -";
                ProjectLabel.Text = "Project : -";
                StatusLabel.Text = "Status : -";
                return;
            }

            StudentLabel.Text = $"Student : {review.StudentName}";
            FacultyLabel.Text = $"Faculty : {review.FacultyName}";
            ProjectLabel.Text = $"Project : {review.ProjectTitle}";
            StatusLabel.Text = $"Status : {review.Status}";
            LastSyncLabel.Text =
    $"Last Sync : {DateTime.Now:dd MMM yyyy  hh:mm:ss tt}";

            AddLog("200 OK");
        }
        catch (Exception ex)
        {
            AddLog(ex.ToString());
            
        }
    }

    private async void GetAllClicked(object sender, EventArgs e)
    {
        try
        {
            AddLog("GET /api/Review");

            var reviews = await _api.GetAllReviews();

            if (reviews == null)
            {
                AddLog("No reviews found.");
                return;
            }

            AddLog($"Retrieved {reviews.Count} Reviews");

            foreach (var review in reviews)
            {
                AddLog($"{review.Id} - {review.StudentName}");
            }
            LastSyncLabel.Text =
    $"Last Sync : {DateTime.Now:dd MMM yyyy  hh:mm:ss tt}";
        }
        catch (Exception ex)
        {
            AddLog(ex.ToString());
        }
    }
}