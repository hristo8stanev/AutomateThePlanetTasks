using System.Text;
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
        var newAlbum = await CreateUniqueAlbum();
        var json = JsonConvert.SerializeObject(newAlbum);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var newAlbumRequest = await _httpClient.PostAsync(_endpoints.AlbumsEndPoint, data);
        var responseJsonResult = await newAlbumRequest.Content.ReadAsStringAsync();
        var insertedAlbum = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        var request = await _httpClient.GetAsync($"{_endpoints.AlbumsEndPoint}{insertedAlbum.AlbumId}");
        var responseJsonResults = await newAlbumRequest.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        request.EnsureSuccessStatusCode();
        Assert.AreEqual(insertedAlbum.AlbumId, response.AlbumId);
        Assert.AreEqual(insertedAlbum.Title, response.Title);
    }
}