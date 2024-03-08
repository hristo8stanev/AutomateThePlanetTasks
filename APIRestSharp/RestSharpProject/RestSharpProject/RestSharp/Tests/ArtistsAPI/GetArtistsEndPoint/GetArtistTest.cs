using System.Net;

namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.GetArtistsEndPoint
{
    public class GetArtistTest : BaseRestSharp
    {
       
        [Test]
        public async Task ContentPopulated_When_GetArtist()
        {

            var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Get);
            var response = await _restClient.ExecuteAsync(request);

            response.AssertStatusCode(HttpStatusCode.OK);
            Assert.IsNotNull(response.Content);
        }

        [Test]
        public async Task ContentPopulated_When_GetArtistById()
        {
            var newArtist = await CreateUniqueArtists();
            var newArtistRequest = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
            newArtistRequest.AddJsonBody(newArtist);
            var insertedArtist = await _restClient.ExecuteAsync<Artists>(newArtistRequest);

            var request = new RestRequest($"{_endpoints.ArtistEndPoint}/{insertedArtist.Data.ArtistId}", Method.Get);
            var response = await _restClient.ExecuteAsync<Artists>(request);

            response.AssertStatusCode(HttpStatusCode.OK);
            Assert.AreEqual(insertedArtist.Data.ArtistId, response.Data.ArtistId);
            Assert.AreEqual(insertedArtist.Data.Name, response.Data.Name);
        }
    }
}
