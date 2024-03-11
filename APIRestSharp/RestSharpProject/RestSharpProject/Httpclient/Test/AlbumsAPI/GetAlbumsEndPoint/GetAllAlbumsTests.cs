using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.AlbumsAPI.GetAlbumsEndPoint;
public class GetAllAlbumsTests : BaseHttpClient
{
    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var response = await _httpClient.GetAsync(_endpoints.AlbumsEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Album>>(responseJsonResult);

       response.EnsureSuccessStatusCode();
       Assert.IsNotNull(albums);
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var response = await _httpClient.GetAsync($"{_endpoints.AlbumsEndPoint}10");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        Assert.AreEqual(10, result.AlbumId);
        response.EnsureSuccessStatusCode();
    }

}
