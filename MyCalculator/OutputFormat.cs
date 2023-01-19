using System.Text.RegularExpressions;

namespace MyCalculator
{
    /// <summary>
    /// Output format class
    /// </summary>
    public static class OutputFormat
    {
        /// <summary>
        /// Output format
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        public static string Format(string s)
        {
            s = CanNotDivideByZero(
                    ConvertEmptyToZero(
                        AddCommas(
                            RemoveCommas(
                                RemoveRepeatDecimalPoints(
                                    RemoveLeadingZeros(
                                        s
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
        private static string RemoveLeadingZeros(string s)
        {
            string pattern = @"^0+(?!\.)";
            s = Regex.Replace(s, pattern, "");
            return s;
        }

        /// <summary>
        /// Remove repeat decimal points
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private static string RemoveRepeatDecimalPoints(string s)
        {
            string pattern = @"\.";
            MatchCollection matches = Regex.Matches(s, pattern);
            for (int i = matches.Count - 1; i > 0; i--)
            {
                s = s.Remove(matches[i].Index, 1);
            }

            return s;
        }

        /// <summary>
        /// Convert empty string to zero
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private static string ConvertEmptyToZero(string s)
        {
            string pattern = @"^[-]?$";
            s = Regex.Replace(s, pattern, "0");

            return s;
        }

        /// <summary>
        /// Remove commas
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private static string RemoveCommas(string s)
        {
            string pattern = @",";
            s = Regex.Replace(s, pattern, "");

            return s;
        }

        /// <summary>
        /// Add commas
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private static string AddCommas(string s)
        {
            string pattern = @"([-]?\d)(?=(\d{3})+$)";
            string[] arr = s.Split('.');
            arr[0] = Regex.Replace(arr[0], pattern, "$1,");
            s = string.Join(".", arr);

            return s;
        }

        /// <summary>
        /// Can not divide by zero
        /// </summary>
        /// <param name="s">String input</param>
        /// <returns>Formal output</returns>
        private static string CanNotDivideByZero(string s)
        {
            string pattern = @"∞";
            s = Regex.Replace(s, pattern, "無法除以零");

            return s;
        }
    }
}
