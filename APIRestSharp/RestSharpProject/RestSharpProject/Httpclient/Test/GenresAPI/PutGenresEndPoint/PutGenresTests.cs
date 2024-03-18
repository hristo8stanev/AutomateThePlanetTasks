using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.GenresAPI.PutGenresEndPoint;
public class PutGenresTests : BaseHttpClient
{

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenre = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.GenresEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedGenres = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Name = updatedName;
        json = JsonConvert.SerializeObject(insertedGenres);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"{_endpoints.GenresEndPoint}/{insertedGenres.GenreId}", data);

        var getResponse = await _httpClient.GetAsync($"{_endpoints.GenresEndPoint}/{insertedGenres.GenreId}");
        var getResponseJsonResult = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedGenres = JsonConvert.DeserializeObject<Genres>(getResponseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);
    }
}
