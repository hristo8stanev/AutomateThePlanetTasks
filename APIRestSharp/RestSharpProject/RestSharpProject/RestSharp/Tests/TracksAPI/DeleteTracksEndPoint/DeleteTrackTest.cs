namespace RestSharpProject.RestSharp.Tests.TracksAPI.DeleteTracksEndPoint
{
    public class DeleteTrackTest : BaseRestSharp
    {
        [Test]
        public async Task TracksDeleted_When_PerformetGenericDeleteRequest()
        {
            var newTrack = await CreateUniqueTrack();
            var request = new RestRequest($"{_endpoints.TrackEndPoint}", Method.Post);
            request.AddJsonBody(newTrack);
            await _restClient.ExecuteAsync<Tracks>(request);

            var deleteRequest = new RestRequest($"{_endpoints.TrackEndPoint}/{newTrack.TrackId}", Method.Delete);
            var response = await _restClient.ExecuteAsync<Tracks>(deleteRequest);

            response.AssertSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessful);


        }
    }
}
