using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.GenresAPI.DeleteGenresEndPoint;
public class DeleteGenresTests : BaseHttpClient
{

    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.GenresEndPoint, data);

        var deleteResponse = await _httpClient.DeleteAsync($"api/Artists/{newArtist.ArtistId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
    }
}