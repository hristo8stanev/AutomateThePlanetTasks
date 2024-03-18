namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.PostAlbumEndPoint;

public class PostAlbumTest : BaseRestSharp
{


    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    { 
        var newAlbum = await CreateUniqueAlbum();

        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        request.AddJsonBody(newAlbum);

        var response = await _restClient.ExecuteAsync<Album>(request);
      

        response.AssertSuccessStatusCode();
        Assert.AreEqual(response.Data.Title, newAlbum.Title);

        //assert JSON schema
        response.AssertSchema(_jsonSchemas.AlbumSchema);
    }
}