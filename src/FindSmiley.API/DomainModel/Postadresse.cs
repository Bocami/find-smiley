namespace FindSmiley.API.DomainModel
{
    public class Postadresse
    {
        private readonly string adresse1;
        private readonly string postnummer;
        private readonly string by;

        public Postadresse(string adresse1, string postnummer, string @by)
        {
            this.adresse1 = adresse1;
            this.postnummer = postnummer;
            this.@by = @by;
        }

        public string Adresse1
        {
            get { return adresse1; }
        }

        public string Postnummer
        {
            get { return postnummer; }
        }

        public string By 
        {
            get { return by; }
        }
    }
}
