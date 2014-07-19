namespace FindSmiley.API.DomainModel
{
    public class Virksomhed
    {
        private readonly int id;
        private readonly string navn;
        private readonly Virksomhedstyper type;
        private readonly Postadresse postadresse;
        private readonly Geo geo;
        private readonly bool harEliteSmiley;
        private readonly Kontrolrapport[] kontrolrapporter;

        public Virksomhed(int id, string navn, Virksomhedstyper type, Postadresse postadresse, Geo geo, bool harEliteSmiley, Kontrolrapport[] kontrolrapporter)
        {
            this.id = id;
            this.navn = navn;
            this.type = type;
            this.postadresse = postadresse;
            this.geo = geo;
            this.harEliteSmiley = harEliteSmiley;
            this.kontrolrapporter = kontrolrapporter;
        }

        public int Id
        {
            get { return id; }
        }

        public string Navn 
        {
            get { return navn; }
        }

        public Postadresse Postadresse 
        {
            get { return postadresse; }
        }

        public Geo Geo 
        {
            get { return geo; }
        }

        public bool HarEliteSmiley 
        {
            get { return harEliteSmiley; }
        }

        public Virksomhedstyper Type 
        {
            get { return type; }
        }

        public Kontrolrapport[] Kontrolrapporter 
        {
            get { return kontrolrapporter; }
        }
    }
}
