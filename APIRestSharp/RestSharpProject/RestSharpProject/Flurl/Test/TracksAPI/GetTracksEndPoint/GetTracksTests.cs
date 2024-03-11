using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.TracksAPI.GetTracksEndPoint;
    public class GetTracksTests : BaseFlurlAPI
    {

    [Test]
    public async Task ContentPopulated_When_GetAllTracks()
    {
        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.TracksEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.NotNull(response.ResponseMessage);
    }


    [Test]
    public async Task ContentPopulated_When_GetGenresById()
        {
            var response = await BASE_URL
                .AppendPathSegment(_flurlEndPoints.TracksEndPoint)
                .AppendPathSegment(10)
                .WithOAuthBearerToken(AUTH_TOKEN)
                .GetAsync();

            response.ResponseMessage.EnsureSuccessStatusCode();
            Assert.NotNull(response.ResponseMessage);
        }
    }
