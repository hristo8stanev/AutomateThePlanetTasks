using Flurl.Http;
using Newtonsoft.Json;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.AlbumsAPI.GetAlbumsEndPoint;
public class GetAlbumsTests : BaseFlurlAPI
    {

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {




        var responseJsonResult = await BASE_URL
             .AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
             .AppendPathSegment(10)
             .WithOAuthBearerToken(AUTH_TOKEN)
             .GetStringAsync();

        var result = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        Assert.AreEqual(10, result.AlbumId);
      
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var albums = await BASE_URL
              .AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
              .WithOAuthBearerToken(AUTH_TOKEN)
              .GetJsonAsync<List<Album>>();

        Assert.AreEqual(584, albums.Count);

    }

}

