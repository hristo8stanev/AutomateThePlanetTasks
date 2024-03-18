namespace RestSharpProject.RestSharp.Tests.GenresAPI.PutGenresEndPoint;
public class PutGenresTest : BaseRestSharp

{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
        request.AddJsonBody(newGenres);

        var insertedGenres = await _restClient.ExecuteAsync<Genres>(request);

        RestRequest putRequest = new RestRequest($"{_endpoints.GenresEndPoint}/{insertedGenres.Data.GenreId}", Method.Put);
        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Data.Name = updatedName;
        putRequest.AddJsonBody(insertedGenres.Data);

        await _restClient.ExecuteAsync(putRequest);

        request = new RestRequest($"{_endpoints.GenresEndPoint}/{insertedGenres.Data.GenreId}", Method.Get);

        var getUpdatedResponse = await _restClient.ExecuteAsync<Genres>(request);

        Assert.IsNotNull(getUpdatedResponse.Content);

    }
}

