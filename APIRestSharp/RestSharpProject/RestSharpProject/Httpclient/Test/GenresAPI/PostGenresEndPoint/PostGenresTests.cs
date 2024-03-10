using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.GenresAPI.PostGenresEndPoint;
public class PostGenresTests : BaseHttpClient
{

    [Test]
    public async Task ContentPopulated_When_NewAlbumInsertedViaPost()
    {
        var newGenre = await CreateUniqueGenres();

        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Genres", data);

        Assert.IsNotNull(response.Content);
    }



    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newGenre = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Genres", data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var createdGenre = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

        Assert.AreEqual(newGenre.Name, createdGenre.Name);
    }
}

