namespace FindSmiley.API.Models.Import
{
    public class VirksomhedData
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public string By { get; set; }
        public bool HarEliteSmiley { get; set; }
    }
}