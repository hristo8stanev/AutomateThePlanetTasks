using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.AlbumsAPI.PostAlbumsEndPoint;
public class PostAlbumsTests : BaseHttpClient
{

    [Test]
    public async Task DataPopulatedAsAlbums_When_NewAlbumInsertedViaPost()
    {
       
        var newAlbum = await CreateUniqueAlbum();
        var json = JsonConvert.SerializeObject(newAlbum);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.AlbumsEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        response.EnsureSuccessStatusCode(); 
        Assert.AreEqual(newAlbum.Title, result.Title);
    }
}