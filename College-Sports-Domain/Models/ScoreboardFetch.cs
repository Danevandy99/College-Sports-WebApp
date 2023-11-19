namespace College_Sports_Domain.Models;

public class ScoreboardFetch
{
    public int Id { get; set; }

    public DateOnly FilterDate { get; set; }

    public required string JsonResponse { get; set; }
}