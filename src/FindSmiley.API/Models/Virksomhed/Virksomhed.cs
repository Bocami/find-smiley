namespace FindSmiley.API.Models.Virksomhed
{
    public class Virksomhed
    {
        private Virksomhed()
        {
        }

        public Virksomhed(int id, string navn, Postadresse postadresse, bool harEliteSmiley)
        {
            Id = id;
            Navn = navn;
            Postadresse = postadresse;
            HarEliteSmiley = harEliteSmiley;
        }

        public int Id { get; private set; }
        public string Navn { get; set; }
        public Postadresse Postadresse { get; set; }
        public bool HarEliteSmiley { get; set; }
    }
}
