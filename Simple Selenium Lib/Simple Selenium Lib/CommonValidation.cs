using OpenQA.Selenium;

namespace Simple_Selenium_Lib
{
   public class CommonValidation
    {
        /// <summary>
        /// Check to see if a passed web element is / is not read only
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool ControlIsReadOnly(IWebElement element)
        {
            if (element.TagName == "div")
            {
                return (true);
            }
            else
            {
                bool enabled = false;
                enabled = element.Enabled;
                return (enabled == false);
            }
        }
    }
}
