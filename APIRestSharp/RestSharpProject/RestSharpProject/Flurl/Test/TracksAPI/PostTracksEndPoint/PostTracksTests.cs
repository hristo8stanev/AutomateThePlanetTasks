using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.TracksAPI.PostTracksEndPoint;
public class PostTracksTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_NewTracksViaPost()
    {
        var newTracks = await CreateUniqueTracks();
        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .PostJsonAsync(newTracks);

        var createdGenre = await response.GetJsonAsync<Genres>();

        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.AreEqual(newTracks.Name, createdGenre.Name);

    }
}