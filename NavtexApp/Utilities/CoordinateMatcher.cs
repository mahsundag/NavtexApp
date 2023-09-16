using System.Text.RegularExpressions;
using NavtexApp.Models;

namespace NavtexApp.Utilities
{
    public static class CoordinateMatcher
    {
        public static List<CoordinatePattern> Patterns { get; set; } = new List<CoordinatePattern>
               {
            new CoordinatePattern
{
    Regex = new Regex(@"(\d{1,2}-\d{4}[NSEW]\s\d{1,3}-\d{4}[NSEW])(\.|\,|\s|$)"),
    Definition = "Format like xx-xxxxN xxx-xxxxW/E with dashes."
},
            new CoordinatePattern
{
    Regex = new Regex(@"(\d{1,3}[NSEW]\s\d{1,3}[NSEW])(\.|\,|\s|$)"),
    Definition = "Simple format like xxN xxW, without decimals or dashes."
},
                    new CoordinatePattern { Regex = new Regex(@"(\d{1,3}-\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew](\s+|\.))(\d{1,3}-\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew](\s+|\.))?"), Definition = "Format like xx-xx.xN xxx-xx.xE, xx-xx.xN or xxx-xx.xE." },
                    new CoordinatePattern { Regex = new Regex(@"(\d{1,2}\s?\d{2}\s?[NSEWnsew](\s+|\.))(\d{1,2}\s?\d{2}\s?[NSEWnsew](\s+|\.))?"), Definition = "Format like xx xxN xx xxE, xx xxN or xx xxE." },
                    new CoordinatePattern { Regex = new Regex(@"\b(\d{1,3}\s?[NSEWnsew](\s+|\.))\b(\d{1,3}\s?[NSEWnsew](\s+|\.))?"), Definition = "Simple format like xxN xxE." },
                    new CoordinatePattern { Regex = new Regex(@"(\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew]\s?-\s?\d{1,3}-\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew](\s+|\.))?"), Definition = "Format like xx,xx N - xxx-xx,xx E/W." },
                    new CoordinatePattern { Regex = new Regex(@"(\d{1,2}\s\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew]?\s?-?\s?\d{1,3}\s?-?\s?\d{1,2}([.,]\d{1,2})?\s?[NSEWnsew](\s+|\.))?"), Definition = "Advanced format including optional hyphens, spaces, and decimal points." },
        new CoordinatePattern { Regex = new Regex(@"(\d{1,2}\s\d{4}\s[NSEW]\s-\s\d{1,3}\s\d{4}\s[NSEW](\.|\s|$))"),
            Definition = "Format like xx xxxx N - xxx xxxx W/E with spaces between numbers and ending with space or period." },

                };
      
    }
}
