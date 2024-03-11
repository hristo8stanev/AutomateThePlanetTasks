using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.GenresAPI.DeleteGenresEndPoint;
public class DeleteGenresTests : BaseHttpClient
{

    [Test]
    public async Task GenresDeleted_When_PerformDeleteRequest()
    {
        var newGenres = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenres);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.GenresEndPoint, data);

        var deleteResponse = await _httpClient.DeleteAsync($"{_endpoints.GenresEndPoint}/{newGenres.GenreId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
    }
}