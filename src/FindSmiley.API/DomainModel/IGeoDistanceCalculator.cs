namespace FindSmiley.API.DomainModel
{
    public interface IGeoDistanceCalculator
    {
        double Calculate(Geo geo1, Geo geo2);
    }
}
