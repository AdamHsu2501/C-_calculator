namespace MyCalculator
{
    /// <summary>
    /// Clear button
    /// </summary>
    public class ClearButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            manager.Init();
        }
    }
}
