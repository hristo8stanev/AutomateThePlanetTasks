using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using HttpTracer;
using HttpTracer.Logger;
using RestSharpProject.RestSharp.EndPoints;
using System.Xml.Schema;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace RestSharpProject.RestSharp.BaseClass;
public class BaseRestSharp
{
    protected Endpoints _endpoints;
    public XmlSchemaSet _xmlSchemaSet;
    public JsonSchemas _jsonSchemas;
    protected string BASE_URL => "http://localhost:60715/";
    protected static RestClient _restClient;
    protected ExtentReports _extent;
    protected ExtentTest _test;
   
    [OneTimeSetUp]
    public void ClassSetup()
    {
        _jsonSchemas = new JsonSchemas();
        _endpoints = new Endpoints();
        

       // var htmlReporter = new ExtentHtmlReporter("TestReport.html");
       // _extent = new ExtentReports();
       // _extent.AttachReporter(htmlReporter);
       //
       //
       // _extent = new ExtentReports();
       // _extent.AttachReporter(htmlReporter);

        var options = new RestClientOptions(BASE_URL)
        {
            ThrowOnAnyError = true,
            MaxTimeout = 1000,
            FollowRedirects = true,
            MaxRedirects = 10,
            ConfigureMessageHandler = handler => new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.All)
        };

        options.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
       "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs",
       "Bearer");

        var settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        _restClient = new RestClient(options);
    }

    [OneTimeTearDown]
    public void TestCleanup()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : TestContext.CurrentContext.Result.Message;
        // Log test result
        if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            _test.Log(Status.Fail, "Test Failed: " + errorMessage);
            _test.Fail("Snapshot below: " + _test.AddScreenCaptureFromPath(Capture(_restClient)));
        }


        _restClient.Dispose();
    }

    protected async Task<Artists> CreateUniqueArtists()
    {
        var artists = await _restClient.GetAsync<List<Artists>>(new RestRequest(_endpoints.ArtistEndPoint));
        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }

    protected async Task<Genres> CreateUniqueGenres()
    {
        var genres = await _restClient.GetAsync<List<Genres>>(new RestRequest(_endpoints.GenresEndPoint));
        var newGenres = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = genres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenres;
    }

    protected async Task<Album> CreateUniqueAlbum()
    {
        var albums = await _restClient.GetAsync<List<Album>>(new RestRequest(_endpoints.AlbumsEndPoint));

        var newAlbum = new Album
        {
             AlbumId = albums.OrderBy(x => x.AlbumId).Last().AlbumId + 1,
             Title = Guid.NewGuid() + "TitleName".ToString(),
           
        };

        return newAlbum;
     }

    protected async Task<Tracks> CreateUniqueTrack()
    {
        var tracks = await _restClient.GetAsync<List<Tracks>>(new RestRequest(_endpoints.TrackEndPoint));
        var newTrack = new Tracks
        {
            TrackId = tracks.OrderBy(x => x.TrackId).Last().TrackId + 1,
            Name = Guid.NewGuid() + "TrackName".ToString(),
            MediaTypeId = 1,
            Composer = Guid.NewGuid() + "ComposerName".ToString(),
            UnitPrice = Guid.NewGuid() + "88".ToString(),

        };

        return newTrack;
    }

    public static string Capture(RestClient _restClient)
    {
        string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".png";
        string screenShotPath = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots\" + fileName;
        ITakesScreenshot takesScreenshot = (ITakesScreenshot)_restClient;
        Screenshot screenshot = takesScreenshot.GetScreenshot();
        screenshot.SaveAsFile(screenShotPath);
        return screenShotPath;
    }
}
