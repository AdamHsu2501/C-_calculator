using System.Text.RegularExpressions;

namespace MyCalculator
{
    /// <summary>
    /// Output format class
    /// </summary>
    public class OutputFormat
    {
        /// <summary>
        /// Output format
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        public string Format(string s)
        {
            s = CanNotDivideByZero(
                    ConvertEmptyToZero(
                        AddCommas(
                            RemoveCommas(
                                RemoveRepeatDecimalPoints(
                                     AddLeadingZeros(
                                        RemoveLeadingZeros(
                                           
                                            s
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
            return s;
        }

        /// <summary>
        /// Remove leading zeros
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string RemoveLeadingZeros(string s)
        {
            string pattern = @"^0+(?!\.)";
            s = Regex.Replace(s, pattern, "");
            System.Console.WriteLine("RemoveLeadingZeros "+s );
            return s;
        }

        private string AddLeadingZeros(string s)
        {
            string pattern = @"^\.";
            s = Regex.Replace(s, pattern, "0" + s);
            System.Console.WriteLine("AddLeadingZeros " + s );
            return s;
        }

        /// <summary>
        /// Remove repeat decimal points
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string RemoveRepeatDecimalPoints(string s)
        {
            string pattern = @"\.";
            MatchCollection matches = Regex.Matches(s, pattern);
            for (int i = matches.Count - 1; i > 0; i--)
            {
                s = s.Remove(matches[i].Index, 1);
            }
            System.Console.WriteLine("RemoveRepeatDecimalPoints " + s);

            return s;
        }

        /// <summary>
        /// Convert empty string to zero
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string ConvertEmptyToZero(string s)
        {
            string pattern = @"^-?0?$";
            s = Regex.Replace(s, pattern, "0");
            System.Console.WriteLine("ConvertEmptyToZero " + s);

            return s;
        }

        /// <summary>
        /// Remove commas
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string RemoveCommas(string s)
        {
            string pattern = @",";
            s = Regex.Replace(s, pattern, "");
            System.Console.WriteLine("RemoveCommas " + s);

            return s;
        }

        /// <summary>
        /// Add commas
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string AddCommas(string s)
        {
            string pattern = @"([-]?\d)(?=(\d{3})+$)";
            string[] arr = s.Split('.');
            arr[0] = Regex.Replace(arr[0], pattern, "$1,");
            s = string.Join(".", arr);
            System.Console.WriteLine("AddCommas " + s);

            return s;
        }

        /// <summary>
        /// Can not divide by zero
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private string CanNotDivideByZero(string s)
        {
            string pattern = @"∞";
            s = Regex.Replace(s, pattern, "無法除以零");

            System.Console.WriteLine("CanNotDivideByZero " + s);
            return s;
        }
    }
}
