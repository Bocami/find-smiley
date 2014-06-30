namespace FindSmiley.API.Models.Virksomhed
{
    public interface IVirksomhedService
    {
        VirksomhedDto HentVirksomhed(int virksomhedId);
        VirksomhedDto[] HentVirksomheder();
    }
}