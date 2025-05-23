using System.Net;
using FluentAssertions;
using MovieAPITests.HelperClasses;
using RestSharp;

namespace MovieAPITests
{
    public class Tests
    {
        RestRequests requests = new RestRequests("https://localhost:5005/api/GetMoviesByTitleWithPagination?MovieTitle=Spider&PageNumber=1&PageSize=10&SortColumn=Title");

        [Test]
        public void SearchMovies()
        {
            RestResponse response = requests.GetApiRequest();
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}