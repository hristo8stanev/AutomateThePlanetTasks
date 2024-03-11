using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.ArtistsAPI.PostArtistsEndPoint;
public class PostArtistsTests : BaseFlurlAPI
{
    [Test]
    public async Task ContentPopulated_When_NewArtistInsertedViaPost()
    {
        var newArtist = await CreateUniqueArtists();

        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostJsonAsync(newArtist);

        var createdArtist = await response.GetJsonAsync<Artists>();

        Assert.AreEqual(newArtist.Name, createdArtist.Name);
        response.ResponseMessage.EnsureSuccessStatusCode();
    }
}
