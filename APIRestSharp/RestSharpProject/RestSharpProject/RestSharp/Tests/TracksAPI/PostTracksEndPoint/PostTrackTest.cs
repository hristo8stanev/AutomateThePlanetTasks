namespace RestSharpProject.RestSharp.Tests.TracksAPI.PostTracksEndPoint;
    public class PostTrackTest : BaseRestSharp
    {

        [Test]
        public async Task DataPopulatedTracksS_When_NewTrackInsertedViaPost()
        {
            var newTrack = await CreateUniqueTrack();

            var request = new RestRequest(_endpoints.TrackEndPoint, Method.Post);
            request.AddJsonBody(newTrack);

            var response = await _restClient.ExecuteAsync<Tracks>(request);

            response.AssertSuccessStatusCode();
            Assert.AreEqual(response.Data.Name, newTrack.Name);

            //assert JSON schema
            response.AssertSchema(_jsonSchemas.TrackSchema);

        }
    }