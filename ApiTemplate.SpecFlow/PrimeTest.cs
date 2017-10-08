namespace ApiTemplate.SpecFlow
{
    using Xunit;

    public class PrimeService_IsPrimeShould
    {
        public PrimeService_IsPrimeShould()
        {
            //_primeService = new PrimeService();
        }

        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            Assert.False(1 > 2);
        }
    }
}
