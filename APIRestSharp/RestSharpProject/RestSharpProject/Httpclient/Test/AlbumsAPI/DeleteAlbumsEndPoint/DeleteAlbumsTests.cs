using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.AlbumsAPI.DeleteAlbumsEndPoint;
public class DeleteAlbumsTests : BaseHttpClient
{
    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newAlbum = await CreateUniqueAlbum();
        var json = JsonConvert.SerializeObject(newAlbum);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.AlbumsEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedAlbum = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        var deleteResponse = await _httpClient.DeleteAsync($"{_endpoints.AlbumsEndPoint}{newAlbum.AlbumId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);

    }
}