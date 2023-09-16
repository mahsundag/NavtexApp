namespace NavtexApp.Services
{
    public interface ICoordinateParserService
    {
        string Parse(string text);
        string GetExactText(string text);

        string Highlight(string text);
    }
}
