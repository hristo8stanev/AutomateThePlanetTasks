using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.AlbumsAPI.PutAlbumsEndPoint;
public class PutAlbumsTests : BaseHttpClient
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {


        var newAlbum = await CreateUniqueAlbum();
        var json = JsonConvert.SerializeObject(newAlbum);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.AlbumsEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedAlbum = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        string updatedTitle = Guid.NewGuid() + "UpdateDTitle".ToString();
        insertedAlbum.Title = updatedTitle;
        json = JsonConvert.SerializeObject(insertedAlbum);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"{_endpoints.AlbumsEndPoint}{insertedAlbum.AlbumId}", data);

        var getResponse = await _httpClient.GetAsync($"{_endpoints.AlbumsEndPoint}{insertedAlbum.AlbumId}");
        var getResponseJsonResult = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedGenres = JsonConvert.DeserializeObject<Album>(getResponseJsonResult);

        Assert.AreEqual(updatedTitle, actualUpdatedGenres.Title);
        response.EnsureSuccessStatusCode();
    }
}
