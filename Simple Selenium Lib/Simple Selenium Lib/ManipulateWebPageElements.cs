using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Simple_Selenium_Lib
{
    public class ManipulateWebPageElements
    {
        #region Set Up Elements For Test
        public int NotChangedCounter = 0;
        #endregion

        /// <summary>
        /// Change the value of an already found textbox, with a new string value. 
        /// </summary>
        /// <param name="FoundTextBox">Found element from 'FindElementByID' or 'FindElementByLinkText'</param>
        /// <param name="NewValueFortextBox">New string value for textbox </param>
        /// <returns></returns>
        public bool ChangeValueOfTextBox(IWebElement FoundTextBox, string NewValueForTextBox)
        {
            bool IsTextBoxtextChanged = false;

            try
            {
                if (NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    if (CommonValidation.ControlIsReadOnly(FoundTextBox) == false)
                    {
                        FoundTextBox.Click(); // We need to click the found text box
                        FoundTextBox.Clear(); // We need to clear it's current contents
                        FoundTextBox.SendKeys(NewValueForTextBox); //Send the new value 

                        // Find what the new value of the text box is.
                        string NewTextBoxValue = FoundTextBox.GetAttribute("value").ToString();

                        //The new value should not equal the passed value
                        if (NewTextBoxValue == NewValueForTextBox)
                        {
                            IsTextBoxtextChanged = true;
                            Assert.IsTrue(IsTextBoxtextChanged);
                        }
                        else
                        {
                            IsTextBoxtextChanged = false;
                            Assert.Fail();
                        }
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                   + Environment.NewLine + "Element " + FoundTextBox.Location + "Is Read Only");
                        Assert.Fail();
                    }
                }
            }
            catch (Exception simpleSeleniumLibException)
            {
                //Mitigate stale references and try again
                if (simpleSeleniumLibException is StaleElementReferenceException && NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    NotChangedCounter++;
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The TextBox which should have had a value change "
                                    + FoundTextBox.Location.ToString() + "was not edited"
                                    + Environment.NewLine + "Attempting change again to mitigate 'Stale Reference Exceptions..."
                                    + Environment.NewLine + "Change Count: " + NotChangedCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                    ChangeValueOfTextBox(FoundTextBox, NewValueForTextBox);
                }
                else
                {
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The TextBox which should have had a value change "
                                    + FoundTextBox.Location.ToString() + "failed due to an exception in the code "
                                    + Environment.NewLine + "Asserting Inconclusive ");
                    Assert.Inconclusive();
                }
            }
            NotChangedCounter = 0;
            return IsTextBoxtextChanged;
        }

        /// <summary>
        /// Change the radio button to either Position 0 or 1
        /// Key Point: The passed element must derive from the element found via the 
        /// FindRadioButtonByID method
        /// </summary>
        /// <param name="FoundRadioButton"> Collection of states relating to one Web Element</param>
        /// <returns></returns>
        public bool ChangeValueOfRadioButton(IReadOnlyCollection<IWebElement> FoundRadioButton)
        {
            bool IsRadioButtonChanged = false;
            bool RadioButtonPosition = false;

            try
            {
                if (NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    if (FoundRadioButton.ElementAt(1).Enabled == true)
                    {
                        RadioButtonPosition = FoundRadioButton.ElementAt(0).Selected; // See which index we are on

                        if (RadioButtonPosition == true)
                        {
                            FoundRadioButton.ElementAt(1).Click();
                        }
                        else
                        {
                            FoundRadioButton.ElementAt(0).Click();
                        }
                    }
                }
            }
            catch (Exception simpleSeleniumLibException)
            {
                //Mitigate stale references and try again
                if (simpleSeleniumLibException is StaleElementReferenceException && NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    NotChangedCounter++;
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The Radio Button which should have changed state "
                                    + FoundRadioButton.ElementAt(0).Location.ToString() + "was not changed"
                                    + Environment.NewLine + "Attempting change again to mitigate 'Stale Reference Exceptions..."
                                    + Environment.NewLine + "Change Count: " + NotChangedCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);
                }
                else
                {
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The Radio Button which should have changed state "
                                    + FoundRadioButton.ElementAt(0).Location.ToString() + "failed due to an exception in the code "
                                    + Environment.NewLine + "Asserting Inconclusive ");
                    Assert.Inconclusive();
                }
            }
            NotChangedCounter = 0;
            return IsRadioButtonChanged;
        }

        /// <summary>
        /// Change the value of a drop down element. 
        /// </summary>
        /// <param name="FoundTextBox"></param>
        /// <param name="NewValueForDropDown"></param>
        /// <returns></returns>
        public bool ChangeValueOfDropDown(IWebElement FoundDropDown, string NewValueForDropDown)
        {
            bool IsNewValueSelected = false;
            try
            {
                if (NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    if (CommonValidation.ControlIsReadOnly(FoundDropDown) == false)
                    {
                        SelectElement SelectedDropDown = new SelectElement(FoundDropDown);

                        SelectedDropDown.SelectByText(NewValueForDropDown);
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                   + Environment.NewLine + "Element " + FoundDropDown.Location + "Is Read Only");
                        Assert.Fail();
                    }
                }
            }
            catch (Exception simpleSeleniumLibException)
            {
                //Mitigate stale references and try again
                if (simpleSeleniumLibException is StaleElementReferenceException && NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    NotChangedCounter++;
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The DropDown which should have had a value change "
                                    + FoundDropDown.Location.ToString() + "failed due to an exception in the code "
                                    + Environment.NewLine + "Change Count: " + NotChangedCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                    ChangeValueOfDropDown(FoundDropDown, NewValueForDropDown);
                }
                else
                {
                    Trace.WriteLine("Simple Selenium Lib"
                                   + Environment.NewLine + simpleSeleniumLibException + "Error: The DropDown which should have had a value change "
                                   + FoundDropDown.Location.ToString() + "failed due to an exception in the code "
                                   + Environment.NewLine + "Asserting Inconclusive ");
                    Assert.Inconclusive();
                }
            }

            NotChangedCounter = 0;
            return IsNewValueSelected;
        }

        /// <summary>
        /// Click button on Web Page
        /// </summary>
        /// <param name="FoundButton"></param>
        /// <returns></returns>
        public bool ClickButton(IWebElement FoundButton)
        {
            bool WasButtonClicked = false;

            try
            {
                if (NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    if (CommonValidation.ControlIsReadOnly(FoundButton) == false)
                    {
                        FoundButton.Click();
                    }
                    else
                    {
                        Trace.WriteLine("Simple Selenium Lib"
                                   + Environment.NewLine + "Element " + FoundButton.Location + "Is Read Only");
                        Assert.Fail();
                    }
                }
            }
            catch (Exception simpleSeleniumLibException)
            {
                //Mitigate stale references and try again
                if (simpleSeleniumLibException is StaleElementReferenceException && NotChangedCounter <= GlobalTestElements.MAX_SEARCH_NUMBER)
                {
                    NotChangedCounter++;
                    Trace.WriteLine("Simple Selenium Lib"
                                    + Environment.NewLine + simpleSeleniumLibException + "Error: The button which should have been clicked, was not "
                                    + FoundButton.Location.ToString() + "failed due to an exception in the code "
                                    + Environment.NewLine + "Attempting change again to mitigate 'Stale Reference Exceptions... "
                                    + Environment.NewLine + "Change Count: " + NotChangedCounter + " /" + GlobalTestElements.MAX_SEARCH_NUMBER);

                    ClickButton(FoundButton);
                }
                else
                {
                    Trace.WriteLine("Simple Selenium Lib"
                                   + Environment.NewLine + simpleSeleniumLibException + "Error: The button which should have been clicked, was not "
                                   + FoundButton.Location.ToString() + "failed due to an exception in the code "
                                   + Environment.NewLine + "Asserting Inconclusive ");
                    Assert.Inconclusive();
                }
            }

            return WasButtonClicked;
        }
    }
}
