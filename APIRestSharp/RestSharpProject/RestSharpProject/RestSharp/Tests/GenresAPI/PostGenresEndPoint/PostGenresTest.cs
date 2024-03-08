namespace RestSharpProject.RestSharp.Tests.GenresAPI.PostGenresEndPoint;
public class PostGenresTest : BaseRestSharp
{
 
    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
        request.AddJsonBody(newGenres);

        var response = await _restClient.ExecuteAsync<Genres>(request);

        response.AssertSuccessStatusCode();
        Assert.AreEqual(newGenres.Name, response.Data.Name);
        Assert.IsNotNull(newGenres.GenreId);
    }
}
