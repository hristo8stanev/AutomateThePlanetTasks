using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.GenresAPI.PutGenresEndPoint;
public class PutGenresTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL.AppendPathSegments(_flurlEndPoints.GenresEndPoint)
                                     .WithOAuthBearerToken(AUTH_TOKEN)
                                     .PostJsonAsync(newGenre);
        RegenerateUrl();

        var createdGenre = await response.GetJsonAsync<Genres>();

        string updatedName = Guid.NewGuid().ToString();
        createdGenre.Name = updatedName;

        var putResponse = await BASE_URL.AppendPathSegment(_flurlEndPoints.GenresEndPoint)
                                .AppendPathSegment(createdGenre.GenreId)
                                .WithOAuthBearerToken(AUTH_TOKEN)
                                .PutJsonAsync(createdGenre);
        RegenerateUrl();

        var actualUpdatedGenres = await BASE_URL.AppendPathSegments(_flurlEndPoints.GenresEndPoint)
                               .AppendPathSegment(createdGenre.GenreId)
                               .WithOAuthBearerToken(AUTH_TOKEN)
                               .GetJsonAsync<Genres>();
        RegenerateUrl();

        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);
    }
}

