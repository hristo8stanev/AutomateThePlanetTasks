namespace RestSharpProject.RestSharp.Tests.TracksAPI.GetTracksEndPoint;
    public class GetTracksTest : BaseRestSharp
    {

    [Test]
    public async Task DataPopulatedTracksS_When_GetAllTrack()
    {
        var request = new RestRequest(_endpoints.TracksEndPoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        Assert.IsNotNull(response.Content);
        response.AssertSuccessStatusCode();
    }

    [Test]
    public async Task DataPopulatedTracks_WhenGetTrackById()
    {
        var newTrack = await CreateUniqueTrack();
        var newTrackRequest = new RestRequest(_endpoints.TracksEndPoint, Method.Post);
        newTrackRequest.AddJsonBody(newTrack);
        var insertedTrack = await _restClient.ExecuteAsync<Tracks>(newTrackRequest);

      
        var request = new RestRequest(($"{_endpoints.TracksEndPoint}/{insertedTrack.Data.TrackId}"), Method.Get);
        var response = await _restClient.ExecuteAsync<Tracks>(request);

        
        response.AssertSuccessStatusCode();
        Assert.AreEqual(insertedTrack.Data.TrackId, response.Data.TrackId);
        Assert.AreEqual(insertedTrack.Data.Name, response.Data.Name);
    }
}
