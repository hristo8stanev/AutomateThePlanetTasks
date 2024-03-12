using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.TracksAPI.PutTracksEndPoint;
public class PutTracksTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {

        var newTracks = await CreateUniqueTracks();
        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .PostJsonAsync(newTracks);
        RegenerateUrl();

        var createdTrack = await response.GetJsonAsync<Tracks>();

        string updatedName = Guid.NewGuid().ToString();
        createdTrack.Name = updatedName;

        var putResponse = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint).AppendPathSegment(createdTrack.TrackId).WithOAuthBearerToken(AUTH_TOKEN).PutJsonAsync(createdTrack);

        RegenerateUrl();

        var actualUpdatedTrack = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint).AppendPathSegment(createdTrack.TrackId).WithOAuthBearerToken(AUTH_TOKEN).GetJsonAsync<Tracks>();

        Assert.AreEqual(updatedName, actualUpdatedTrack.Name);
        response.ResponseMessage.EnsureSuccessStatusCode();
    }
}
