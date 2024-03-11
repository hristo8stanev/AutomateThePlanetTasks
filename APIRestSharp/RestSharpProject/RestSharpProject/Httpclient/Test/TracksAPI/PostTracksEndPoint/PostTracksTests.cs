using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.TracksAPI.PostTracksEndPointl;
public class PostTracksTests : BaseHttpClient
    {

    [Test]
    public async Task ContentPopulated_When_NewAlbumInsertedViaPost()
    {
        var newTrack = await CreateUniqueTrack();
        var json = JsonConvert.SerializeObject(newTrack);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.TrackEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedTracks = JsonConvert.DeserializeObject<Tracks>(responseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newTrack.Name, insertedTracks.Name);
    }
}