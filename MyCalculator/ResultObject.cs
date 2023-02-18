namespace MyCalculator
{
    /// <summary>
    /// Response result class
    /// </summary>
    public class ResultObject
    {
        /// <summary>
        /// Input formula
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Infix of formula
        /// </summary>
        public string Infix { get; set; }

        /// <summary>
        /// Prefix of formula
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Postfix of formula
        /// </summary>
        public string Postfix { get; set; }

        /// <summary>
        /// Result of formula
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Name of current calculator state 
        /// </summary>
        public string StateName { get; set; }
    }
}
