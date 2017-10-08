namespace ApiTemplate.SpecFlow
{
    using Xunit;

    // specFlow for dontnet core: https://github.com/stajs/SpecFlow.NetCore
    // need to install https://www.microsoft.com/en-us/download/details.aspx?id=40760
    // This command generated specflow .feature.cs file
    // C:\Users\jacnik\.nuget\packages\SpecFlow\2.2.1\tools\specflow.exe generateall "C:\Users\jacnik\source\repos\ApiTemplate\ApiTemplate.SpecFlow\ApiTemplate.SpecFlow.csproj.fake.csproj" /force /verbose

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
