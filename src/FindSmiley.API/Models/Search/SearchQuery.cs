namespace FindSmiley.API.Models.Search
{
    public class SearchQuery
    {
        public string Keywords { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Offset { get; set; }
    }
}