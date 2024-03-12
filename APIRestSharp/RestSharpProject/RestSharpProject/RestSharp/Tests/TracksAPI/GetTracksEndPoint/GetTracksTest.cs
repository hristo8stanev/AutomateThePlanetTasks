using RestSharpProject.Models;

namespace RestSharpProject.RestSharp.Tests.TracksAPI.GetTracksEndPoint;
    public class GetTracksTest : BaseRestSharp
    {

    [Test]
    public async Task DataPopulatedTracksS_When_GetAllTrack()
    {
        var request = new RestRequest(_endpoints.TrackEndPoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        Assert.IsNotNull(response.Content);
        response.AssertSuccessStatusCode();
    }

    [Test]
    public async Task DataPopulatedTracks_WhenGetTrackById()
    {
        var newTrack = await CreateUniqueTrack();
        var newTrackRequest = new RestRequest(_endpoints.TrackEndPoint, Method.Post);
        newTrackRequest.AddJsonBody(newTrack);
        var insertedTrack = await _restClient.ExecuteAsync<Tracks>(newTrackRequest);

      
        var request = new RestRequest(($"{_endpoints.TrackEndPoint}/{insertedTrack.Data.TrackId}"), Method.Get);
        var response = await _restClient.ExecuteAsync<Tracks>(request);

        
        response.AssertSuccessStatusCode();
        Assert.AreEqual(insertedTrack.Data.TrackId, response.Data.TrackId);
        Assert.AreEqual(insertedTrack.Data.Name, response.Data.Name);
    }


    [Test]
    public async Task DataPopulatedAsList_When_DataDrivenTestTracksById([Values("1", "2", "3", "4", "5", "6", "7", "8", "9", "10")] string trackId)
    {
       
        var request = new RestRequest($"{_endpoints.TrackEndPoint}/{trackId}", Method.Get);
        var response = await _restClient.ExecuteAsync<Tracks>(request);

        var insertedArtistRequest = new RestRequest($"{_endpoints.TrackEndPoint}/{trackId}", Method.Get);
        var insertedArtistResponse = await _restClient.ExecuteAsync<Tracks>(insertedArtistRequest);

       
        Assert.AreEqual(response.Data.TrackId, insertedArtistResponse.Data.TrackId);
        response.AssertSuccessStatusCode();
    }
}