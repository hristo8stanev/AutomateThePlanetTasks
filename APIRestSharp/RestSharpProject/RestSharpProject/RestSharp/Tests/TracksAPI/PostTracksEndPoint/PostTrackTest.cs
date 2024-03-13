using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharpProject.AssertiExtensions;

namespace RestSharpProject.RestSharp.Tests.TracksAPI.PostTracksEndPoint
{
    public class PostTrackTest : BaseRestSharp
    {

        [Test]
        public async Task DataPopulatedTracksS_When_NewTrackInsertedViaPost()
        {
            var newTrack = await CreateUniqueTrack();

            var request = new RestRequest(_endpoints.TrackEndPoint, Method.Post);
            request.AddJsonBody(newTrack);

            var response = await _restClient.ExecuteAsync<Tracks>(request);

            response.AssertSuccessStatusCode();
            Assert.AreEqual(response.Data.Name, newTrack.Name);

        }

        [Test]
        public async Task TestValidTrackJsonSchema()
        {
            var jsonData = @"{""trackId"":1,""name"":""For Those About To Rock (We Salute You)"",""albumId"":1,""mediaTypeId"":1,""genreId"":1,""composer"":""Angus Young, Malcolm Young, Brian Johnson"",""milliseconds"":343719,""bytes"":11170334,""unitPrice"":""0.99"",""album"":null,""genre"":null,""mediaType"":null,""invoiceItems"":[],""playlistTrack"":[]}";

            var request = new RestRequest(_endpoints.TrackEndPoint, Method.Post);
            request.AddJsonBody(jsonData);

           // var response = await _restClient.ExecuteAsync<Tracks>(request);
           // response.AssertSuccessStatusCode();

            string jsonSchema = File.ReadAllText(@"C:\Users\UsernameT\Documents\GitHub\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestTrackBodySchema.txt");
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
}
