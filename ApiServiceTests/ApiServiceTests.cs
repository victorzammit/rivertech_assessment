using LightBDD.Framework.Scenarios;
using LightBDD.NUnit3;
using Newtonsoft.Json.Linq;

namespace ApiServiceTests
{
    [TestFixture]
    public class ApiServiceTests : FeatureFixture
    {
        private ApiService _apiService;
        private JObject _response;

        [SetUp]
        public void Setup()
        {
            _apiService = new ApiService();
        }

        [Scenario]
        public async Task Should_Return_Valid_UserData()
        {
            await Runner.RunScenarioAsync(
                given => an_api_service(),
                when => i_request_user_data(),
                then => the_response_should_contain_valid_fields()
            );
        }

        private Task an_api_service()
        {
            Assert.IsNotNull(_apiService);
            return Task.CompletedTask; // Return Task for async compatibility
        }

        private async Task i_request_user_data()
        {
            _response = await _apiService.GetUserData(); // Perform API request
        }

        private Task the_response_should_contain_valid_fields()
        {
            Assert.NotNull(_response);

            // Validate top-level fields
            Assert.That((int)_response["id"], Is.EqualTo(1));
            Assert.That((string)_response["name"], Is.EqualTo("Leanne Graham"));
            Assert.That((string)_response["username"], Is.EqualTo("Bret"));
            Assert.That((string)_response["email"], Is.EqualTo("Sincere@april.biz"));
            Assert.That((string)_response["phone"], Is.EqualTo("1-770-736-8031 x56442"));
            Assert.That((string)_response["website"], Is.EqualTo("hildegard.org"));

            // Validate address fields
            var address = _response["address"] as JObject;
            Assert.NotNull(address);
            Assert.That((string)address["street"], Is.EqualTo("Kulas Light"));
            Assert.That((string)address["suite"], Is.EqualTo("Apt. 556"));
            Assert.That((string)address["city"], Is.EqualTo("Gwenborough"));
            Assert.That((string)address["zipcode"], Is.EqualTo("92998-3874"));

            // Validate geo fields
            var geo = address["geo"] as JObject;
            Assert.NotNull(geo);
            Assert.That((string)geo["lat"], Is.EqualTo("-37.3159"));
            Assert.That((string)geo["lng"], Is.EqualTo("81.1496"));

            // Validate company fields
            var company = _response["company"] as JObject;
            Assert.NotNull(company);
            Assert.That((string)company["name"], Is.EqualTo("Romaguera-Crona"));
            Assert.That((string)company["catchPhrase"], Is.EqualTo("Multi-layered client-server neural-net"));
            Assert.That((string)company["bs"], Is.EqualTo("harness real-time e-markets"));

            return Task.CompletedTask; // Return Task for async compatibility
        }
    }
}