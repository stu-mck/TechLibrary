using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class CalculationSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            //ScenarioContext.Current.Pending();
            var c = new Calculator();
            ScenarioContext.Current.Add("c", c);  
            c.Enter(p0);
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            var c = (Calculator)ScenarioContext.Current["c"];
            c.Enter(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var c = (Calculator)ScenarioContext.Current["c"];
            c.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            var c = (Calculator)ScenarioContext.Current["c"];
            var result = c.Result();

            Assert.AreEqual(p0, result);
        }
    }
}
