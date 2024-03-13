using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace RestSharpProject.RestSharp.Tests.GenresAPI.PostGenresEndPoint;
public class PostGenresTest : BaseRestSharp
{
 
    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
        request.AddJsonBody(newGenres);

        var response = await _restClient.ExecuteAsync<Genres>(request);

        response.AssertSuccessStatusCode();
        Assert.AreEqual(newGenres.Name, response.Data.Name);
        Assert.IsNotNull(newGenres.GenreId);
    }


    [Test]
    public async Task TestValidGenreJsonSchema()
    {
        var jsonData = @"{""genreId"":0,""name"":""testName"",""tracks"":[]}";
        var request = new RestRequest(_endpoints.GenresEndPoint, Method.Post);
        request.AddJsonBody(jsonData);

        string jsonSchema = File.ReadAllText(@"C:\Users\UsernameT\Documents\GitHub\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestGenreBodySchema.txt");
        JSchema jSchema = JSchema.Parse(jsonSchema);

        JToken jToken = JToken.Parse(jsonData);

        AssertJsonSchema(jSchema, jToken);


    }

    public static void AssertJsonSchema(JSchema jSchema, JToken jToken)
    {
        bool valid = jToken.IsValid(jSchema);

        Console.WriteLine(valid);

        jToken.IsValid(jSchema, out IList<ValidationError> errors);

        foreach (ValidationError err in errors)
        {
            Console.WriteLine(err.Message);
        }
    }
   
}
