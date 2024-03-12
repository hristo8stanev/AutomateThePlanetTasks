using System.Net;

namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.GetAlbumsEndPoint;
public class GetAllAlbumsTests : BaseRestSharp
{
    
    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.IsNotNull(response.Content);

    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {

        var newAlbum = await CreateUniqueAlbum();
        var newAlbumRequest = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        newAlbumRequest.AddJsonBody(newAlbum);
        var insertedAlbum = await _restClient.ExecuteAsync<Album>(newAlbumRequest);

        var request = new RestRequest($"{_endpoints.AlbumsEndPoint}{insertedAlbum.Data.AlbumId}");
        var response = await _restClient.ExecuteAsync<Album>(request);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.AreEqual(insertedAlbum.Data.AlbumId, response.Data.AlbumId);
        Assert.AreEqual(insertedAlbum.Data.Title, response.Data.Title);

    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var request = new RestRequest(_endpoints.AlbumsEndPoint);
        var response = await _restClient.ExecuteAsync<List<Album>>(request);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.IsNotNull(response.Data.Count);
    }

    [Test]
    public async Task DataPopulatedAsList_When_DataDrivenTestAlbumsById([Values("1", "2", "3", "4", "5", "6", "7", "8", "9", "10")] string albumId)
    {
       
        var request = new RestRequest($"{_endpoints.AlbumsEndPoint}{albumId}", Method.Get);
        var response = await _restClient.ExecuteAsync<Album>(request);

       
        var insertedAlbumRequest = new RestRequest($"{_endpoints.AlbumsEndPoint}{albumId}", Method.Get);
        var insertedAlbumResponse = await _restClient.ExecuteAsync<Album>(insertedAlbumRequest);

        insertedAlbumResponse.AssertSuccessStatusCode();
        Assert.AreEqual(response.Data.AlbumId, insertedAlbumResponse.Data.AlbumId);
        Assert.AreEqual(response.Data.Title, insertedAlbumResponse.Data.Title);
    }
}