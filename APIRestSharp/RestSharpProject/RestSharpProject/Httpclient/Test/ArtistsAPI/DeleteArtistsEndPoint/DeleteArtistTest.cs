using Newtonsoft.Json;
using System.Text;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.ArtistsAPI.DeleteArtistsEndPoint;
    public class DeleteArtistTest : BaseHttpClient
    {


    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.ArtistEndPoint, data);

        var deleteResponse = await _httpClient.DeleteAsync($"{_endpoints.ArtistEndPoint}/{newArtist.ArtistId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
    }
}