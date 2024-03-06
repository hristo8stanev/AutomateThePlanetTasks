using AutoFixture;
using Dasync.Collections;
using Examples.Models;
using HttpTracer;
using HttpTracer.Logger;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using RestSharp.Serializers;
using RestSharp.Serializers.NewtonsoftJson;
using System.Net;
using System.Threading.Tasks;

namespace Examples;

[TestFixture]
public class AssertApiAssertionsTests
{
    private RestClient _restClient;
    private Fixture _fixture;

    [SetUp]
    public void TestInit()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var options = new RestClientOptions("http://localhost:60715/")
        {
            ThrowOnAnyError = true,
            //Timeout = 1000,
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
        _restClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson(settings));
        // https://restsharp.dev/authenticators.html#oauth2

        // TODO: install separate NuGet package
        // Newtonsoft.Json.JsonSerializationException : Self referencing loop detected for property 'task' with type 'System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[BookOneExamples.Chapter18.Artists,BookOneExamples.Chapter18.MediaStoreApiTests+<CreateUniqueArtists>d__13]'. Path 'stateMachine.<>t__builder'.


    }

    [Test]
    public async Task AssertSuccessStatusCode()
    {
        var request = new RestRequest("api/Albums", Method.Get);

        var response = await _restClient.ExecuteAsync(request);

        response.AssertSuccessStatusCode();
    }

    [Test]
    public async Task AssertStatusCodeOk()
    {
        var request = new RestRequest("api/Albums", Method.Get);

        var response = await _restClient.ExecuteAsync(request);

        response.AssertStatusCode(HttpStatusCode.OK);
    }

    [Test]
    public async Task AssertResponseHeaderServerIsEqualToKestrel()
    {
        var request = new RestRequest("api/Albums", Method.Get);

        var response = await _restClient.ExecuteAsync(request);

        response.AssertResponseHeader("server", "Kestrel");
    }

    [Test]
    public async Task AssertContentTypeJson()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentType("application/json");
    }

    [Test]
    public async Task AssertContentContainsAudioslave()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentContains("Audioslave");
    }

    [Test]
    [Ignore("Do not execute")]
    public async Task AssertContentEncodingUtf8()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request).ConfigureAwait(false);

        response.AssertContentEncoding("gzip");
    }

    [Test]
    public async Task AssertContentEquals()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentEquals("{\"albumId\":10,\"title\":\"Audioslave\",\"artistId\":8,\"artist\":null,\"tracks\":[]}");
    }

    [Test]
    public async Task AssertContentNotContainsRammstein()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentNotContains("Rammstein");
    }

    [Test]
    public async Task AssertContentNotEqualsRammstein()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentNotEquals("Rammstein");
    }

    [Test]
    public async Task AssertResultEquals()
    {
        var expectedAlbum = new Albums
        {
            AlbumId = 10,
        };
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertResultEquals(expectedAlbum);
    }

    [Test]
    public async Task AssertResultNotEquals()
    {
        var expectedAlbum = new Albums
        {
            AlbumId = 11,
        };
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertResultNotEquals(expectedAlbum);
    }

    [Test]
    [Ignore("the followin functionality is not implemented in mediaStoreAPI")]
    public async Task AssertCookieExists()
    {
        var request = new RestRequest("api/Albums/10");

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertCookieExists("whoIs");
    }

    [Test]
    [Ignore("the followin functionality is not implemented in mediaStoreAPI")]
    public async Task AssertCookieWhoIsBella()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertCookie("whoIs", "Bella");
    }

    [Test]
    public async Task AssertJsonSchema()
    {
        var request = new RestRequest("api/Albums/10");

        var response = await _restClient.ExecuteAsync<Albums>(request).ConfigureAwait(false);

        // http://json-schema.org/examples.html
        var expectedSchema = @"{
                                    ""title"": ""Albums"",
                                    ""type"": ""object"",
                                    ""properties"": {
                                                ""albumId"": {
                                                    ""type"": ""integer""
                                                },
                                        ""title"": {
                                                    ""type"": ""string""
                                        },
                                        ""artistId"": {
                                                    ""type"": ""integer""
                                        },
 	                                ""artist"": {
                                                    ""type"": [""object"", ""null""]
                                        },
	                                ""tracks"": {
                                                    ""type"": ""array""
                                        }
                                            },
                                    ""required"": [""albumId""]
                                  }";
        response.AssertSchema(expectedSchema);
    }
}