using Npgsql;
using ReviewFlow.Api.Models;

namespace ReviewFlow.Api.Services;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("PostgresConnection")!;
    }

    public List<ReviewRequest> GetAllReviews()
    {
        List<ReviewRequest> reviews = new();

        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = "SELECT * FROM ReviewRequests";

        using var command = new NpgsqlCommand(query, connection);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            reviews.Add(new ReviewRequest
            {
                Id = Convert.ToInt32(reader["Id"]),
                StudentName = reader["StudentName"].ToString()!,
                FacultyName = reader["FacultyName"].ToString()!,
                ProjectTitle = reader["ProjectTitle"].ToString()!,
                Status = reader["Status"].ToString()!
            });
        }

        return reviews;
    }

    public void AddReview(ReviewRequest review)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = @"INSERT INTO ReviewRequests
                    (StudentName, FacultyName, ProjectTitle, Status)
                    VALUES
                    (@StudentName, @FacultyName, @ProjectTitle, @Status)";

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("@StudentName", review.StudentName);
        command.Parameters.AddWithValue("@FacultyName", review.FacultyName);
        command.Parameters.AddWithValue("@ProjectTitle", review.ProjectTitle);
        command.Parameters.AddWithValue("@Status", review.Status);

        command.ExecuteNonQuery();
    }

    public void UpdateReview(int id, ReviewRequest review)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = @"UPDATE ReviewRequests
                     SET StudentName=@StudentName,
                         FacultyName=@FacultyName,
                         ProjectTitle=@ProjectTitle,
                         Status=@Status
                     WHERE ""Id""=@Id";

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("@StudentName", review.StudentName);
        command.Parameters.AddWithValue("@FacultyName", review.FacultyName);
        command.Parameters.AddWithValue("@ProjectTitle", review.ProjectTitle);
        command.Parameters.AddWithValue("@Status", review.Status);
        command.Parameters.AddWithValue("@Id", id);

        command.ExecuteNonQuery();
    }

    public void DeleteReview(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = "DELETE FROM ReviewRequests WHERE \"Id\" = @Id";

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        command.ExecuteNonQuery();
    }

    public ReviewRequest? GetReviewById(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = "SELECT * FROM ReviewRequests WHERE \"Id\"=@Id";

        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new ReviewRequest
            {
                Id = Convert.ToInt32(reader["Id"]),
                StudentName = reader["StudentName"].ToString()!,
                FacultyName = reader["FacultyName"].ToString()!,
                ProjectTitle = reader["ProjectTitle"].ToString()!,
                Status = reader["Status"].ToString()!
            };
        }

        return null;
    }

    public ReviewRequest? GetByName(string s)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Open();

        string query = @"SELECT * 
                     FROM ReviewRequests
                     WHERE ""studentname"" = @StudentName";

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("@StudentName", s);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new ReviewRequest
            {
                Id = Convert.ToInt32(reader["Id"]),
                StudentName = reader["StudentName"].ToString()!,
                FacultyName = reader["FacultyName"].ToString()!,
                ProjectTitle = reader["ProjectTitle"].ToString()!,
                Status = reader["Status"].ToString()!
            };
        }

        return null;
    }
}