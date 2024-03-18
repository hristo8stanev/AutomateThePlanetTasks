namespace RestSharpProject.RestSharp.Tests.GenresAPI.DeleteGenresEndPoint;
    public class DeleteGenresTest : BaseRestSharp
{
    [Test]
    public async Task GenresDelete_When_PerformGenericDeleteRequests()
    {

        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
        request.AddJsonBody(newGenres);

        var insertedGenres = await _restClient.ExecuteAsync<Genres>(request);

        var deleteRequest = new RestRequest($"{_endpoints.GenresEndPoint}/{insertedGenres.Data.GenreId}", Method.Delete);
        var response = await _restClient.ExecuteAsync<Genres>(deleteRequest);

        Assert.IsTrue(response.IsSuccessful);
        response.AssertSuccessStatusCode();
    }
}
