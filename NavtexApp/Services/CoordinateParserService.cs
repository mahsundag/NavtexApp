namespace NavtexApp.Services
{
    public class CoordinateParserService : ICoordinateParserService
    {
        public string GetExactText(string text)
        {
            int startIndex = text.IndexOf("ZCZC");
            int endIndex = text.IndexOf("NNNN",startIndex);

            if (startIndex == -1 || endIndex == -1 || endIndex < startIndex)
                return null;

            if (endIndex + 4 >= text.Length)  
                return null;

            return text.Substring(startIndex, (endIndex + 4) - startIndex);
        }

        public string Highlight(string text)
        {
           var result = GetExactText(text);
           var coordinates = Parse(result);
           return $"<span class=\"highlighted\">{result}</span>";
        }

        public string Parse(string text)
        {
            return text;
        }
    }
}
