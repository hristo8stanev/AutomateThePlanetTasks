namespace RestSharpProject.RestSharp.Tests.TracksAPI.PutTracksEndPoint;
    public class PutTrackTest : BaseRestSharp
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newTracks = await CreateUniqueTrack();

        var request = new RestRequest(_endpoints.TrackEndPoint, Method.Post);
        request.AddJsonBody(newTracks);

        var insertedTrack = await _restClient.ExecuteAsync<Tracks>(request);

        var putRequest = new RestRequest($"{_endpoints.TrackEndPoint}/{insertedTrack.Data.TrackId}", Method.Put);
        string updatedName = Guid.NewGuid() + "UpdateTrack".ToString();
        insertedTrack.Data.Name = updatedName;
        putRequest.AddJsonBody(insertedTrack.Data);

        await _restClient.ExecuteAsync(putRequest);

        request = new RestRequest($"{_endpoints.TrackEndPoint}/{insertedTrack.Data.TrackId}", Method.Get);
        var getUpdatedResponse = await _restClient.ExecuteAsync<Tracks>(request);

        getUpdatedResponse.AssertSuccessStatusCode();
        Assert.IsNotNull(getUpdatedResponse.Content);
        Assert.AreEqual(insertedTrack.Data.Name, getUpdatedResponse.Data.Name);

    }
}
