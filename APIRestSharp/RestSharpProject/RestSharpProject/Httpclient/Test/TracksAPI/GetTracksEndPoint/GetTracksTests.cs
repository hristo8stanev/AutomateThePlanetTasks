using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.TracksAPI.GetTracksEndPoint;
public class GetTracksTests : BaseHttpClient
{

    [Test]
    public async Task DataPopulateAsList_When_GetAllTracks()
    {
        var response = await _httpClient.GetAsync(_endpoints.TrackEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Tracks>>(responseJsonResult);

        response.EnsureSuccessStatusCode();

    }

    [Test]
    public async Task DataPopulatedAsList_When_GetTracksById()
    {

        var newTrack = await CreateUniqueTrack();
        var json = JsonConvert.SerializeObject(newTrack);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var insertedTrack = await _httpClient.PostAsync(_endpoints.TrackEndPoint, data);

        var response = await _httpClient.GetAsync($"{_endpoints.TrackEndPoint}/{newTrack.TrackId}");
        var respnseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<Tracks>(respnseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newTrack.TrackId, albums.TrackId);
        Assert.AreEqual(newTrack.Name, albums.Name);
    }
}
