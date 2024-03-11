using System.Text;
using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.TracksAPI.PutTracksEndPoint;
public class PutTracksTests : BaseHttpClient
{
    [Test]
    public async Task DataPopulated_When_PutModifiedContent()
    {
        var newTracks = await CreateUniqueTrack();
        var json = JsonConvert.SerializeObject(newTracks);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.TrackEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedTracks = JsonConvert.DeserializeObject<Tracks>(responseJsonResult);

        string updatedTrack = Guid.NewGuid() + "UpdatedTrack".ToString();
        insertedTracks.Name = updatedTrack;
        json = JsonConvert.SerializeObject(insertedTracks);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"{_endpoints.TrackEndPoint}/{insertedTracks.TrackId}", data);

        var getResponse = await _httpClient.GetAsync($"{_endpoints.TrackEndPoint}/{insertedTracks.TrackId}");
        var getResponseJsonReulst = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedTracks = JsonConvert.DeserializeObject<Tracks>(getResponseJsonReulst);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(updatedTrack, actualUpdatedTracks.Name);

    }
}