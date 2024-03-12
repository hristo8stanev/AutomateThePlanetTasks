using RestSharpProject.Models;

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


        [Test]
        public async Task DataPopulatedAsList_When_DataDrivenTestGenresById([Values("1", "2", "3", "4", "5", "6", "7", "8", "9", "10")] string genreId)
        {
            var request = new RestRequest($"{_endpoints.GenresEndPoint}/{genreId}", Method.Get);
            var response = await _restClient.ExecuteAsync<Genres>(request);

            var insertedArtistRequest = new RestRequest($"{_endpoints.GenresEndPoint}/{genreId}", Method.Get);
            var insertedArtistResponse = await _restClient.ExecuteAsync<Genres>(insertedArtistRequest);


            Assert.AreEqual(response.Data.GenreId, insertedArtistResponse.Data.GenreId);
            response.AssertSuccessStatusCode();

        }
    }
}
