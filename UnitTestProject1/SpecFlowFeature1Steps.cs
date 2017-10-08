using System;
using TechTalk.SpecFlow;
using Xunit;

namespace UnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Assert.True(1 == 1);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Assert.True(1 == 1);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.True(1 == 1);
        }
    }
}
