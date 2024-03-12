using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.TracksAPI.DeleteTracksEndPoint;
public class DeleteTracksTests : BaseFlurlAPI
    {

    [Test]
    public async Task TracksDeleted_When_PerformGenericDeleteRequest()
    {
        var newTrack = await CreateUniqueTracks();

        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .PostJsonAsync(newTrack);
        RegenerateUrl();

        var deleteResponse = await BASE_URL.AppendPathSegments(_flurlEndPoints.TracksEndPoint, newTrack.TrackId)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .DeleteAsync();

        deleteResponse.ResponseMessage.EnsureSuccessStatusCode();

    }
}
