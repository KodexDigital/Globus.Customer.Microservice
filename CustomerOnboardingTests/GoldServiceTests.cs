using Globus.External.Service.Services;
using Moq;
using Xunit;

namespace CustomerOnboardingTests
{
    public class GoldServiceTests
    {
        [Fact]
        public void Get_Gold_Live_Price_Test()
        {
            var goldService = new Mock<IGoldService>();
            goldService.Setup(g => g.GetGoldPriceLive())
                .ReturnsAsync(new Globus.Core.Common.ResponseModel<Globus.External.Service.Responses.GoldLivePriceResponse>());
        }
    }
}
