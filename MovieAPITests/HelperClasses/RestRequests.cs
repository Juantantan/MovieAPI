
using RestSharp;

namespace MovieAPITests.HelperClasses
{
    public class RestRequests(string RequestUrlSuffix)
    {
        // const string baseUrl = "https://localhost:5005/";

        public RestResponse GetApiRequest()
        {
            RestClient client = new RestClient(RequestUrlSuffix);
            RestRequest restRequest = new RestRequest(RequestUrlSuffix, Method.Get);
            RestResponse restResponse = client.Execute(restRequest); ;

            return restResponse;
        }

    }
}
