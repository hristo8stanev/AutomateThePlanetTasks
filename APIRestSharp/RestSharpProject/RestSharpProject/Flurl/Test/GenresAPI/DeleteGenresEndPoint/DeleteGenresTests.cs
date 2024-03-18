using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.GenresAPI.DeleteGenresEndPoint;
public class DeleteGenresTests : BaseFlurlAPI
{

    [Test]
    public async Task GenresDeleted_When_PerformGenericDeleteRequest()
    {
        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.GenresEndPoint)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .PostJsonAsync(newGenre);
        RegenerateUrl();

        var deleteResponse = await BASE_URL.AppendPathSegments(_flurlEndPoints.GenresEndPoint, newGenre.GenreId)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .DeleteAsync();

        deleteResponse.ResponseMessage.EnsureSuccessStatusCode();
    }
}