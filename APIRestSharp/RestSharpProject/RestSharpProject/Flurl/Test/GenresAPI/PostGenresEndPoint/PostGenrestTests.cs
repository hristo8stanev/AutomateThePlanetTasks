using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.GenresAPI.PostGenresEndPoint;
public class PostGenrestTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_NewGenresViaPost()
    {
        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.GenresEndPoint)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .PostJsonAsync(newGenre);

        var createdGenre = await response.GetJsonAsync<Genres>();

        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.AreEqual(newGenre.Name, createdGenre.Name);
    }
}

