using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.AlbumsAPI.DeleteAlbumsEndPoint;
public class DeleteAlbumTests : BaseFlurlAPI
{

    [Test]
    public async Task ArtistsDeleted_When_PerformGenericDeleteRequest()
    {
        var newAlbum = await CreateUniqueAlbum();

        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .PostJsonAsync(newAlbum);
        RegenerateUrl();

        var deleteResponse = await BASE_URL.AppendPathSegments(_flurlEndPoints.AlbumsEndPoint, newAlbum.AlbumId)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .DeleteAsync();

        deleteResponse.ResponseMessage.EnsureSuccessStatusCode();
    }
}