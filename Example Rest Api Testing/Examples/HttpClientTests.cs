using Examples.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Examples;

[TestFixture]
public class HttpClientTests
{
    private static HttpClient _httpClient;
    private const string BASE_URL = "https://localhost:60714/";

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BASE_URL);
        _httpClient.Timeout = TimeSpan.FromMinutes(3);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        // https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        //        var formatters = new List<MediaTypeFormatter>() {
        //    new MyCustomFormatter(),
        //    new JsonMediaTypeFormatter(),
        //    new XmlMediaTypeFormatter()
        //};
        //        resp.Content.ReadAsAsync<IEnumerable<Product>>(formatters);


        //HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
        //response.EnsureSuccessStatusCode();


        //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);


        //[JsonPropertyName("description")]
        //public string Description { get; set; }

        // custom handlers?
    }

    [OneTimeTearDown]
    public void TestCleanup()
    {
        _httpClient.Dispose();

        // or using  var httpClient = new HttpClient();
    }

    [Test]
    [Ignore("Ignore until we implement head request for media store")]
    public async Task HeadRequestExample()
    {
        var request = new HttpRequestMessage(HttpMethod.Head, "api/Albums");

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    [Test]
    [Ignore("Media store Api does not support get request with following parameters")]
    public async Task UpdateUserAgent()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Albums");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        var result = await _httpClient.SendAsync(request);

        Assert.IsNotNull(result.Content);

        // add query parameters
        var builder = new UriBuilder(BASE_URL);
        builder.Query = "id=12556&shouldRegister=True&redirectUrl=automatetheplanet";
        var url = builder.ToString();

        var res = await _httpClient.GetAsync(url);

        // if send via form
        // POST requests are often sent via a post form. The type of the body of the request is indicated
        // by the Content-Type header. The FormUrlEncodedContent is a container for name/value tuples encoded
        // using application/x-www-form-urlencoded MIME type.

        using var client = new HttpClient();

        var data = new Dictionary<string, string>
        {
            {"firstName", "Anton"},
            {"lastName", "Angelov"},
            {"company", "Automate The Planet"}
        };

        var response = await client.PostAsync(url, new FormUrlEncodedContent(data));

        //{
        //  "args": {},
        //  "data": "",
        //  "files": {},
        //  "form": {
        //    "firstName": "Anton",
        //    "lastName": "Angelov"
        //    "company": "AutomateThePlanet"
        //  },
        //  "headers": {
        //    "Content-Length": "33",
        //    "Content-Type": "application/x-www-form-urlencoded",
        //    "Host": "localhost",
        //  },
        //  "json": null,
        //  ...
        //  "url": "http://localhost:5001/"
        //}
    }

    [Test]
    public async Task DownloadImage()
    {
        using var httpClient = new HttpClient();

        var url = "https://www.automatetheplanet.com/wp-content/uploads/2020/03/atp_logo.svg";
        byte[] imageBytes = await httpClient.GetByteArrayAsync(url);

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        string localFilename = "atp_logo.svg";
        string localPath = Path.Combine(documentsPath, localFilename);

        Console.WriteLine(localPath);
        File.WriteAllBytes(localPath, imageBytes);
    }

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var response = await _httpClient.GetAsync("api/Albums");

        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task ContentPopulated_When_SendAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Albums");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var response = await _httpClient.GetAsync("api/Albums");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Albums>>(responseJsonResult);

        Assert.AreEqual(347, albums.Count); 
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var response = await _httpClient.GetAsync("api/Albums/10");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Albums>(responseJsonResult);

        Assert.AreEqual(10, result.AlbumId);
    }

    [Test]
    public async Task ContentPopulated_When_GetGenericAlbumsById()
    {
        var response = await _httpClient.GetAsync("api/Albums/10");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Albums>(responseJsonResult);

        Assert.IsNotNull(result);
    }

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenre = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Genres", data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedGenres = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Name = updatedName;
        json = JsonConvert.SerializeObject(insertedGenres);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"api/Genres/{insertedGenres.GenreId}", data);

        var getResponse = await _httpClient.GetAsync($"api/Genres/{insertedGenres.GenreId}");
        var getResponseJsonResult = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedGenres = JsonConvert.DeserializeObject<Genres>(getResponseJsonResult);

        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);
    }

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

    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Artists", data);

        var deleteResponse = await _httpClient.DeleteAsync($"api/Artists/{newArtist.ArtistId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
    }

    private async Task<Artists> CreateUniqueArtists()
    {
        var response = await _httpClient.GetAsync("api/Artists");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var artists = JsonConvert.DeserializeObject<List<Artists>>(responseJsonResult);
        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }

    private async Task<Genres> CreateUniqueGenres()
    {
        var response = await _httpClient.GetAsync("api/Genres");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var allGenres = JsonConvert.DeserializeObject<List<Genres>>(responseJsonResult);
        var newGenre = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = allGenres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenre;
    }
}