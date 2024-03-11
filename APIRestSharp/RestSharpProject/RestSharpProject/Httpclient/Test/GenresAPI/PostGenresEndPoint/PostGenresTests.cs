using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.GenresAPI.PostGenresEndPoint;
public class PostGenresTests : BaseHttpClient
{

    [Test]
    public async Task DataPopulatedAsGenres_When_NewGenresInsertedViaPost()
    {
        var newGenre = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.GenresEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var createdGenre = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newGenre.Name, createdGenre.Name);
    }
}

