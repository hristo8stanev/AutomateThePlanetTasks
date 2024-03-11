using System.Text;
using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using RestSharpProject.Models;

namespace RestSharpProject.Httpclient.Test.GenresAPI.GetGenresEndPoint;
public class GetGenresTests : BaseHttpClient
    {

    [Test]
    public async Task ContentPopulated_When_GetGenericllGenres()
    {
        var response = await _httpClient.GetAsync(_endpoints.GenresEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<Genres>>(responseJsonResult);

        Assert.IsNotNull(result);
        response.EnsureSuccessStatusCode();

    }


    [Test]
    public async Task ContentPopulated_When_GetGenericGenresById()
    {
        var newGenres = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenres);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var insertedTrack = await _httpClient.PostAsync(_endpoints.GenresEndPoint, data);

        var response = await _httpClient.GetAsync($"{_endpoints.GenresEndPoint}/{newGenres.GenreId}");
      
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

       
        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newGenres.GenreId, result.GenreId);
        Assert.AreEqual(newGenres.Name, result.Name);

    }
}

