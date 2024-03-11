using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.ArtistsAPI.PutAlbumsEndPoint;
public class PutAlbumTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newArtist = await CreateUniqueArtists();
        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostJsonAsync(newArtist);

        RegenerateUrl();

        var createdArtist = await response.GetJsonAsync<Artists>();

        string updatedName = Guid.NewGuid().ToString();
        createdArtist.Name = updatedName;

        var putResponse = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
            .AppendPathSegment(newArtist.ArtistId)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PutJsonAsync(createdArtist);

        RegenerateUrl();

        var actualUpdatedArtists = await BASE_URL.AppendPathSegment(_flurlEndPoints.ArtistsEndPoint).AppendPathSegment(createdArtist.ArtistId).WithOAuthBearerToken(AUTH_TOKEN).GetJsonAsync<Artists>();

        RegenerateUrl();
        Assert.AreEqual(updatedName, actualUpdatedArtists.Name);
        response.ResponseMessage.EnsureSuccessStatusCode();


    }
}

