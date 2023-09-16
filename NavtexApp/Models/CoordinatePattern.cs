using System.Text.RegularExpressions;

namespace NavtexApp.Models
{
    public class CoordinatePattern
    {
        public Regex Regex { get; set; }
        public string Definition { get; set; }

        public int Order { get; set; }
    }
}
