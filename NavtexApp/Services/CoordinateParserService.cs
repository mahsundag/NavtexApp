using NavtexApp.Models;
using NavtexApp.Utilities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NavtexApp.Services
{
    public class CoordinateParserService : ICoordinateParserService
    {
        /// <summary>
        /// its gives navtex text between ZCZC and NNNN
        /// </summary>
        /// <param name="text"></param>
        /// <returns>navtex text,if null means this is not navtex</returns>
        public string GetExactText(string text)
        {
            int startIndex = text.IndexOf("ZCZC");
            int endIndex = text.IndexOf("NNNN", startIndex);

            if (startIndex == -1 || endIndex == -1 || endIndex < startIndex)
                return null;

            if (endIndex + 4 > text.Length)
                return null;

            return text.Substring(startIndex, (endIndex + 4) - startIndex);
        }
        /// <summary>
        /// Highlights the coordinates text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>highlighted text </returns>
        public string Highlight(string text)
        {
            var result = GetExactText(text);
            if (result==null)
            {
                return "There is no navtex";
            }
            var coordinates = Parse(result);

            foreach (var coordinate in coordinates)
            {
                if (coordinate.Start<coordinate.End)
                {
                    result = result.Replace(coordinate.Text, $"<span class=\"highlighted\">{coordinate.Text}</span>");
                }
            }



            return result;
        }
        /// <summary>
        /// finds which pattern matches the our list and returns the list of text location details
        /// </summary>
        /// <param name="text"></param>
        /// <returns>list of highlihting texts and text locations (start and end)</returns>
        public List<SearchItem> Parse(string text)
        {
            var list = CoordinateMatcher.Patterns;
            List<SearchItem> results = new List<SearchItem>();
            List<char> charPoints = new List<char>();
            foreach (var pattern in list)
            {
                var matches = pattern.Regex.Matches(text);

                foreach (Match match in matches)
                {
                    int start = text.IndexOf(match.ToString());
                    int end = start + match.ToString().Length;

                    results.Add(new SearchItem { Text = match.ToString(), Start = start, End = end });
                }

            }

            return results
                    .GroupBy(so => so.End)
                    .Select(group => group.OrderBy(so => so.Start).First())
                    .ToList();
        }
    }
}
