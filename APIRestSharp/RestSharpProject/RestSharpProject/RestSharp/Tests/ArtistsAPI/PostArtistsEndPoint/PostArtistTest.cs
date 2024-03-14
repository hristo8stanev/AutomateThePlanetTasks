namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.PostArtistsEndPoint;

public class PostArtistTest : BaseRestSharp
    {

    [Test]
    public async Task DataPopulatedAsArtists_When_NewArtistNameInsertedViaPost()
    {
        var newArtist = await CreateUniqueArtists();

        var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
        request.AddJsonBody(newArtist);

        var response = await _restClient.ExecuteAsync<Artists>(request);

        response.AssertSuccessStatusCode();
        Assert.AreEqual(newArtist.Name, response.Data.Name);

        //assert JSON schema
        response.AssertSchema(_jsonSchemas.ArtistsSchema);
    }
}

   