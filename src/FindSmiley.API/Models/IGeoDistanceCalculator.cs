namespace FindSmiley.API.Models
{
    public interface IGeoDistanceCalculator
    {
        double Calculate(Geo geo1, Geo geo2);
    }
}
