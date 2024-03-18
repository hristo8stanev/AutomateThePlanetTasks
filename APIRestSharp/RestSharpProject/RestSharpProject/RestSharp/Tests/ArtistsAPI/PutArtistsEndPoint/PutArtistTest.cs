namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.PutArtistsEndPoint;
    public class PutArtistTest : BaseRestSharp
    {
   
        [Test]
        public async Task ContentPopulated_When_PutModifiedContent()
        {
            var newArtist = await CreateUniqueArtists();

            var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
            request.AddJsonBody(newArtist);

            var insertedArtists = await _restClient.ExecuteAsync<Artists>(request);

            var putRequest = new RestRequest($"{_endpoints.ArtistEndPoint}/{insertedArtists.Data.ArtistId}", Method.Put);

            string updatedName = Guid.NewGuid().ToString();
            insertedArtists.Data.Name = updatedName;
            putRequest.AddJsonBody(insertedArtists.Data);

            await _restClient.ExecuteAsync(putRequest);

            request = new RestRequest($"{_endpoints.ArtistEndPoint}/{insertedArtists.Data.ArtistId}", Method.Get);

            var getUpdatedResponse = await _restClient.ExecuteAsync<Artists>(request);

            getUpdatedResponse.AssertSuccessStatusCode();
            Assert.IsNotNull(getUpdatedResponse.Content);
            Assert.AreEqual(insertedArtists.Data.Name, getUpdatedResponse.Data.Name);

        }
    }