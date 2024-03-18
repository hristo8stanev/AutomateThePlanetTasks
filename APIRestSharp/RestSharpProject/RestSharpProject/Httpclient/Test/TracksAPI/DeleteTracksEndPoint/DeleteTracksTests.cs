using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.TracksAPI.DeleteTracksEndPoint;
public class DeleteTracksTests : BaseHttpClient
{

    [Test]
    public async Task TracksDeleted_When_PerformDeleteRequest()
    {
        var newTrack = await CreateUniqueTrack();
        var json = JsonConvert.SerializeObject(newTrack);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.TrackEndPoint, data);

        var deleteResponse = await _httpClient.DeleteAsync($"{_endpoints.TrackEndPoint}/{newTrack.TrackId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
        deleteResponse.EnsureSuccessStatusCode();

    }
}