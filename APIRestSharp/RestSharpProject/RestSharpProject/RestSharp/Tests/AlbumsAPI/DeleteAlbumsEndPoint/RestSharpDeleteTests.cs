using System.Net;
using RestSharp;
using RestSharpProject.AssertiExtensions;
using RestSharpProject.RestSharp.BaseClass;

namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.DeleteAlbumsEndPoint;
public class RestSharpDeleteTests : BaseRestSharp
{

    [Test]
    public async Task ArtistsDeleted_When_PerformGenericDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var request = new RestRequest("api/Albums", Method.Post);
        request.AddJsonBody(newArtist);
        await _restClient.ExecuteAsync<Artists>(request);

        var deleteRequest = new RestRequest($"api/Albums/{newArtist.ArtistId}", Method.Delete);
        var response = await _restClient.ExecuteAsync<Artists>(deleteRequest);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var request = new RestRequest("api/Artists", Method.Post);
        request.AddJsonBody(newArtist);
        await _restClient.ExecuteAsync<Artists>(request);

        var deleteRequest = new RestRequest($"api/Artists/{newArtist.ArtistId}", Method.Delete);
        var response = await _restClient.ExecuteAsync(deleteRequest);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.IsTrue(response.IsSuccessful);
        Assert.IsNull(newArtist.ArtistId);
    }

}
