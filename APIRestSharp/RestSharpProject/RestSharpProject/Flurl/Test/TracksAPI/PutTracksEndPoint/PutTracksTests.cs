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

        var createdGenre = await response.GetJsonAsync<Genres>();
    }
}
