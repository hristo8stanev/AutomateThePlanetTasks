using System.Net;
using RestSharp;
using RestSharpProject.AssertiExtensions;
using RestSharpProject.RestSharp.BaseClass;

namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.DeleteAlbumsEndPoint;
public class DeleteAlbumTests : BaseRestSharp
{
    [Test]
    public async Task AlbumDeleted_When_PerformDeleteRequest()
    {
        var newAlbum = await CreateUniqueAlbum();

        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        request.AddJsonBody(newAlbum);
        await _restClient.ExecuteAsync<Album>(request);

        var deleteRequest = new RestRequest($"{_endpoints.AlbumsEndPoint}/{newAlbum.AlbumId}", Method.Delete);
        var response = await _restClient.ExecuteAsync<Album>(deleteRequest);

        response.AssertSuccessStatusCode();
        Assert.IsTrue(response.IsSuccessful);
        
    }
}
