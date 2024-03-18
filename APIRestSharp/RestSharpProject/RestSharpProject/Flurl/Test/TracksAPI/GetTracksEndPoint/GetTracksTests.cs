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
    public async Task ContentPopulated_When_GetTracksById()
    {
        var newTrack = await CreateUniqueTracks();

        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.TracksEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostJsonAsync(newTrack);

        var responseJsonResult = await BASE_URL.AppendPathSegments(newTrack.TrackId)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .GetStringAsync();


        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.NotNull(response.ResponseMessage);
    }
}
