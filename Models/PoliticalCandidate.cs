namespace TrackingApi.Models
{
    public class PoliticalCandidate
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Year { get; set; }
        public string? Party { get; set; }

    }
}