using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.AlbumsAPI.PostAlbumsEndPoint;
public  class PostAlbumsTests : BaseFlurlAPI
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

       
        Assert.AreEqual(newAlbum.Title, createdAlbums.Title);
    }
}

