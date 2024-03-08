namespace RestSharpProject.RestSharp.Tests.GenresAPI.GetGenresEndPoint
{
    public class GetGenresTest : BaseRestSharp
    {
        [Test]
        public async Task ContentPopulated_When_GetAllGeners()
        {
            var request = new RestRequest(_endpoints.GenresEndPoint, Method.Get);
            var response = await _restClient.ExecuteAsync(request);

            Assert.IsNotNull(response);
            response.AssertSuccessStatusCode();

        }


        [Test]
        public async Task ContentPopulated_When_GetAllGenersById()
        {
            var newGenres = await CreateUniqueGenres();
            var newGenresRequest = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
            newGenresRequest.AddJsonBody(newGenres);
            var insertedGenres = await _restClient.ExecuteAsync<Genres>(newGenresRequest);

            var request = new RestRequest($"{_endpoints.GenresEndPoint}/{insertedGenres.Data.GenreId}");
            var response = await _restClient.ExecuteAsync<Genres>(request);

            insertedGenres.AssertSuccessStatusCode();
            Assert.AreEqual(insertedGenres.Data.GenreId, response.Data.GenreId);
            Assert.AreEqual(insertedGenres.Data.Name, response.Data.Name);
        }
    }
}
