using System;
using TechTalk.SpecFlow;

namespace TechLibrary.BDD
{
    [Binding]
    public class FindingArticlesSteps
    {
        [Given(@"I have entered ""(.*)"" into the Manufacturer field")]
        public void GivenIHaveEnteredIntoTheManufacturerField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered ""(.*)"" into the ModelFamily field")]
        public void GivenIHaveEnteredIntoTheModelFamilyField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered ""(.*)"" into the Series field")]
        public void GivenIHaveEnteredIntoTheSeriesField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
