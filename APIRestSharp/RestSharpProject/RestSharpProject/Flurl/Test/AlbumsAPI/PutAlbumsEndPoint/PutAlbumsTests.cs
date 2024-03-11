using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.AlbumsAPI.PutAlbumsEndPoint;
public class PutAlbumsTests : BaseFlurlAPI
{
    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newAlbum = await CreateUniqueAlbum();

        var response = await BASE_URL.AppendPathSegments(_flurlEndPoints.AlbumsEndPoint)
                                     .WithOAuthBearerToken(AUTH_TOKEN)
                                     .PostJsonAsync(newAlbum);
        RegenerateUrl();

        var createdAlbums = await response.GetJsonAsync<Album>();

        string updatedName = Guid.NewGuid().ToString();
        createdAlbums.Title = updatedName;

        var putResponse = await BASE_URL.AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
                                .AppendPathSegment(createdAlbums.AlbumId)
                                .WithOAuthBearerToken(AUTH_TOKEN)
                                .PutJsonAsync(createdAlbums);
        RegenerateUrl();

        var actualUpdatedGenres = await BASE_URL.AppendPathSegments(_flurlEndPoints.AlbumsEndPoint)
                               .AppendPathSegment(createdAlbums.AlbumId)
                               .WithOAuthBearerToken(AUTH_TOKEN)
                               .GetJsonAsync<Album>();
        RegenerateUrl();

        Assert.AreEqual(updatedName, actualUpdatedGenres.Title);
    }
}

