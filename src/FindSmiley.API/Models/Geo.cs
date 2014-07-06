namespace FindSmiley.API.Models
{
    public class Geo
    {
        private readonly double latitude;
        private readonly double longitude;

        public Geo(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double Latitude
        {
            get { return latitude; }
        }

        public double Longitude
        {
            get { return longitude; }
        }

        public static Geo Empty
        {
            get
            {
                return new Geo(0, 0);
            }
        }
    }
}