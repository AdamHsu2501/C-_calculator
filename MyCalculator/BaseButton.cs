namespace MyCalculator
{
    /// <summary>
    /// Button Base class
    /// </summary>
    public class BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public virtual void Click(UIManager manager, string value)
        {
        }
    }
}
