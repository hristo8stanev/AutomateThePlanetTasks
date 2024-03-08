namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.PutAlbumsEndPoint;
public class PutAlbumsTest : BaseRestSharp
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newAlbum = await CreateUniqueAlbum();

        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        request.AddJsonBody(newAlbum);

        var insertedAlbum = await _restClient.ExecuteAsync<Album>(request);

        var putRequest = new RestRequest($"{_endpoints.AlbumsEndPoint}/{insertedAlbum.Data.AlbumId}", Method.Put);
        string updatedName = Guid.NewGuid() + "UpdatedName".ToString();
        insertedAlbum.Data.Title = updatedName;
        putRequest.AddJsonBody(insertedAlbum.Data);

        await _restClient.ExecuteAsync(putRequest);

        request = new RestRequest($"{_endpoints.AlbumsEndPoint}/{insertedAlbum.Data.AlbumId}", Method.Get);
        var getUpdatedResponse = await _restClient.ExecuteAsync<Album>(request);

        getUpdatedResponse.AssertSuccessStatusCode();
        Assert.IsNotNull(getUpdatedResponse.Content);
        Assert.AreEqual(insertedAlbum.Data.Title, getUpdatedResponse.Data.Title);

    }
}
