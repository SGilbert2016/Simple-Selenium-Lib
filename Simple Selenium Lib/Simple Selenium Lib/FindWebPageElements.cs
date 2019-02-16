using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections.Generic;

namespace Simple_Selenium_Lib
{
    public class FindWebPageElements
    {
        #region Set Up Elements For Test
        public int NotFoundCounter = 0;
        private IWebElement TheObjectWeHaveFound;
        IReadOnlyCollection<IWebElement> RadioButtonFound;
        #endregion

        /// <summary>
        /// Find an element on the web page, 
        /// defined by a passed string which is the 'ID' of the element. 
        /// </summary>
        /// <param name="PassedWebElementToFind"> Pass a string of the ID of the element </param>
        /// <param name="PassedWebDriver">Pass the web driver you have defined in your test </param>
        /// <param name="PassedWebDriverWait">Pass the web driver wait you have defined in your test </param>
        /// <returns></returns>
        public IWebElement FindGenericElementByID(string PassedWebElementToFind, IWebDriver PassedWebDriver, WebDriverWait PassedWebDriverWait)
        {
            if (NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
            {
                try
                {
                    TheObjectWeHaveFound = PassedWebDriverWait.Until(WebPage => WebPage.FindElement(By.Id(PassedWebElementToFind)));
                    Assert.Pass();
                }
                catch (Exception simpleSeleniumLibException)
                {
                    //Mitigate stale references and try again
                    if (simpleSeleniumLibException is StaleElementReferenceException && NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                    {
                        NotFoundCounter++;

                        Trace.WriteLine("Simple Selenium Lib"
                                        + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                        + PassedWebElementToFind + "was not found on the web page"
                                        + Environment.NewLine + "Attempting search again to mitigate 'Stale Reference Exceptions... "
                                        + Environment.NewLine + "Search Count: " + NotFoundCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                        FindGenericElementByID(PassedWebElementToFind, PassedWebDriver, PassedWebDriverWait);
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                     + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                     + PassedWebElementToFind + "was not found due to an exception raised in the code"
                                     + Environment.NewLine + "Asserting Inconclusive ");
                        Assert.Inconclusive();
                    }
                }
            }
            else // Web Element not found after x attempts. 
            {
                Assert.Fail();
            }
            NotFoundCounter = 0;
            return TheObjectWeHaveFound;
        }

        /// <summary>
        /// Find an element on the web page, 
        /// defined by a passed string which is the 'Link Text' of the element. 
        /// </summary>
        /// <param name="PassedWebElementToFind"> Pass a string of the ID of the element </param>
        /// <param name="PassedWebDriver">Pass the web driver you have defined in your test </param>
        /// <param name="PassedWebDriverWait">Pass the web driver wait you have defined in your test </param>
        /// <returns></returns>
        public IWebElement FindGenericElementByLinkText(string PassedWebElementToFind, IWebDriver PassedWebDriver, WebDriverWait PassedWebDriverWait)
        {
            if (NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
            {
                try
                {
                    TheObjectWeHaveFound = PassedWebDriverWait.Until(WebPage => WebPage.FindElement(By.LinkText(PassedWebElementToFind)));
                    NotFoundCounter = 0;
                    Assert.Pass();
                }
                catch (Exception simpleSeleniumLibException)
                {
                    //Mitigate stale references and try again
                    if (simpleSeleniumLibException is StaleElementReferenceException && NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                    {
                        NotFoundCounter++;

                        Trace.WriteLine("Simple Selenium Lib"
                                        + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                        + PassedWebElementToFind + "was not found on the web page"
                                        + Environment.NewLine + "Attempting search again to mitigate 'Stale Reference Exceptions... "
                                        + Environment.NewLine + "Search Count: " + NotFoundCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                        FindGenericElementByLinkText(PassedWebElementToFind, PassedWebDriver, PassedWebDriverWait);
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                     + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                     + PassedWebElementToFind + "was not found due to an exception raised in the code"
                                     + Environment.NewLine + "Asserting Inconclusive ");
                        Assert.Inconclusive();
                    }
                }
            }
            else // Web Element not found after x attempts. 
            {
                Assert.Fail();
            }
            NotFoundCounter = 0;
            return TheObjectWeHaveFound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PassedWebElementToFind"></param>
        /// <param name="PassedWebDriver"></param>
        /// <param name="PassedWebDriverWait"></param>
        /// <returns></returns>
        public IReadOnlyCollection<IWebElement> FindRadioButtonByID(string PassedWebElementToFind, IWebDriver PassedWebDriver, WebDriverWait PassedWebDriverWait)
        {
            if (NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
            {
                try
                {
                    RadioButtonFound = PassedWebDriverWait.Until(WebPage => WebPage.FindElements(By.Id(PassedWebElementToFind)));
                    NotFoundCounter = 0;
                    Assert.Pass();
                }
                catch (Exception simpleSeleniumLibException)
                {
                    //Mitigate stale references and try again
                    if (simpleSeleniumLibException is StaleElementReferenceException && NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                    {
                        NotFoundCounter++;

                        Trace.WriteLine("Simple Selenium Lib"
                                        + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                        + PassedWebElementToFind + "was not found on the web page"
                                        + Environment.NewLine + "Attempting search again to mitigate 'Stale Reference Exceptions... "
                                        + Environment.NewLine + "Search Count: " + NotFoundCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                        FindRadioButtonByID(PassedWebElementToFind, PassedWebDriver, PassedWebDriverWait);
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                     + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                     + PassedWebElementToFind + "was not found due to an exception raised in the code"
                                     + Environment.NewLine + "Asserting Inconclusive ");
                        Assert.Inconclusive();
                    }
                }
            }
            else // Web Element not found after x attempts. 
            {
                Assert.Fail();
            }
            NotFoundCounter = 0;
            return RadioButtonFound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PassedWebElementToFind"></param>
        /// <param name="PassedWebDriver"></param>
        /// <param name="PassedWebDriverWait"></param>
        /// <returns></returns>
        public IWebElement FindPageElementByText(string PassedWebElementToFind, IWebDriver PassedWebDriver, WebDriverWait PassedWebDriverWait)
        {
            if (NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
            {
                try
                {
                    TheObjectWeHaveFound = PassedWebDriverWait.Until(WebPage => WebPage.FindElement(By.XPath("//div[text() = '" + PassedWebElementToFind + "']")));
                    NotFoundCounter = 0;
                    Assert.Pass();
                }
                catch (Exception simpleSeleniumLibException)
                {
                    //Mitigate stale references and try again
                    if (simpleSeleniumLibException is StaleElementReferenceException && NotFoundCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                    {
                        NotFoundCounter++;

                        Trace.WriteLine("Simple Selenium Lib"
                                        + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                        + PassedWebElementToFind + "was not found on the web page"
                                        + Environment.NewLine + "Attempting search again to mitigate 'Stale Reference Exceptions... "
                                        + Environment.NewLine + "Search Count: " + NotFoundCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                        FindPageElementByText(PassedWebElementToFind, PassedWebDriver, PassedWebDriverWait);
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                     + Environment.NewLine + "Error: " + simpleSeleniumLibException + "The element searched for "
                                     + PassedWebElementToFind + "was not found due to an exception raised in the code"
                                     + Environment.NewLine + "Asserting Inconclusive ");
                        Assert.Inconclusive();
                    }
                }
            }
            else // Web Element not found after x attempts. 
            {
                Assert.Fail();
            }
            NotFoundCounter = 0;
            return TheObjectWeHaveFound;
        }
    }
}
