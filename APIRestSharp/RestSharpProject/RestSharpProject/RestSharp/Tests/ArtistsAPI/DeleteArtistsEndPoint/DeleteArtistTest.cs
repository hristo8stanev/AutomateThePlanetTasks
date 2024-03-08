namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.DeleteArtistsEndPoint
{
    public class DeleteArtistTest : BaseRestSharp
    {

        [Test]
        public async Task ArtistsDeleted_When_PerformDeleteRequest()
        {
            var newArtist = await CreateUniqueArtists();
            var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
            request.AddJsonBody(newArtist);
            await _restClient.ExecuteAsync<Artists>(request);

            var deleteRequest = new RestRequest($"{_endpoints.ArtistEndPoint}/{newArtist.ArtistId}", Method.Delete);
            var response = await _restClient.ExecuteAsync(deleteRequest);

            response.AssertSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessful);
        }
    }
}