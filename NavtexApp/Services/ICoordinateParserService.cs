using NavtexApp.Models;

namespace NavtexApp.Services
{
    public interface ICoordinateParserService
    {
        List<SearchItem> Parse(string text);
        string GetExactText(string text);

        string Highlight(string text);
    }
}
