namespace College_Sports_Domain.Models
{
    public class ConferencesFetch
    {
        public int Id { get; set; }

        public string JsonResponse { get; set; } = null!;

        public DateTime FetchedDateTime { get; set; }
    }
}