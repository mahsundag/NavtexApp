namespace NavtexApp.Services
{
    public class CoordinateParserService : ICoordinateParserService
    {
        public string GetExactText(string text)
        {
            return text;
        }

        public string Highlight(string text)
        {
           var result = GetExactText(text);
           var coordinates = Parse(result);
           return "<span class=\"highlighted\">vurgulanan</span>";
        }

        public string Parse(string text)
        {
            return text;
        }
    }
}
