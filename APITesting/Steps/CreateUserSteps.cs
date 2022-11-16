using APITesting.Data;
using APITesting.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITesting.Steps
{
    [Binding]
    public class CreateUserSteps
    {
        private HttpResponseMessage httpResponse;
        private CreateUserRequest createUserRequest;
        APIRequest APIRequest;
        public CreateUserSteps(APIRequest aPIRequest)
        {
            APIRequest = aPIRequest;
        }

        [StepDefinition(@"I populate the API call with the first name '(.*)', last name '(.*)' and the job '(.*)'")]
        public void GivenIPopulateTheAPICall(string FirstName, string LastName, string Job)
        {
            createUserRequest = new CreateUserRequest ( FirstName, LastName, Job );
        }

        [StepDefinition(@"I make the API call to create a new user")]
        public async Task WhenIMakeTheAPICallToCreateANewUserAsync()
        {
            httpResponse = await APIRequest.CreateNewUserAsync(createUserRequest);
        }

        [StepDefinition(@"the call is successful, status code is '(.*)'")]
        public void ThenTheCallIsSuccessful(string expected)
        {
            Assert.AreEqual(httpResponse.StatusCode, expected);
        }

        [StepDefinition(@"the user profile is created")]
        public async Task ThenTheUserProfileIsCreated()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseModel>(responseContent);

            Assert.AreEqual(result.Name, createUserRequest.FirstName + createUserRequest.LastName);
            Assert.AreEqual(result.Job, createUserRequest.Job);
        }
    }
}
