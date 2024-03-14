
namespace RestSharpProject.JsonSchema;
public class JsonSchemas
{
    public string AlbumSchema { get; } = @"
        {
            ""$schema"": ""http://json-schema.org/draft-04/schema#"",
            ""type"": ""object"",
            ""properties"": {
                ""albumId"": { ""type"": ""integer"" },
                ""title"": { ""type"": ""string"" },
                ""artistId"": { ""type"": ""integer"" },
                ""artist"": { ""type"": ""null"" },
                ""tracks"": { ""type"": ""array"", ""items"": {} }
            },
            ""required"": [ ""albumId"", ""title"", ""artistId"", ""artist"", ""tracks"" ]
        }
    ";

    public string ArtistsSchema { get; } = @"
{
    ""$schema"": ""http://json-schema.org/draft-06/schema#"",
    ""$ref"": ""#/definitions/Welcome5"",
    ""definitions"": {
        ""Welcome5"": {
            ""type"": ""object"",
            ""additionalProperties"": false,
            ""properties"": {
                ""artistId"": {
                    ""type"": ""integer""
                },
                ""name"": { ""type"": ""string"" },
                ""albums"": {
                    ""type"": ""array"",
                    ""items"": {}
                }
            },
            ""required"": [
                ""albums"",
                ""artistId"",
                ""name""
            ],
            ""title"": ""Welcome5""
        }
    }
}";


    public string GenreSchema { get; } = @"
        {
                 ""$schema"": ""http://json-schema.org/draft-04/schema#"",
                 ""type"": ""object"",
                 ""properties"": {
                   ""genreId"": {
                     ""type"": ""integer""
                   },
                   ""name"": {
                     ""type"": ""string""
                   },
                   ""tracks"": {
                     ""type"": ""array"",
                     ""items"": {}
                   }
                 },
                 ""required"": [
                   ""genreId"",
                   ""name"",
                   ""tracks""
                 ]
                  }";



    public string TrackSchema { get; } = @"
{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""type"": ""object"",
  ""properties"": {
    ""trackId"": { ""type"": ""integer"" },
    ""name"": { ""type"": ""string"" },
    ""albumId"": { ""type"": [""integer"", ""null""] },
    ""mediaTypeId"": { ""type"": ""integer"" },
    ""genreId"": { ""type"": [""integer"", ""null""] },
    ""composer"": { ""type"": ""string"" },
    ""milliseconds"": { ""type"": ""integer"" },
    ""bytes"": { ""type"": [""integer"", ""null""] },
    ""unitPrice"": { ""type"": ""string"" },
    ""album"": { ""type"": ""null"" },
    ""genre"": { ""type"": ""null"" },
    ""mediaType"": { ""type"": ""null"" },
    ""invoiceItems"": { ""type"": ""array"", ""items"": {} },
    ""playlistTrack"": { ""type"": ""array"", ""items"": {} }
  },
  ""required"": [
    ""trackId"",
    ""name"",
    ""albumId"",
    ""mediaTypeId"",
    ""genreId"",
    ""composer"",
    ""milliseconds"",
    ""bytes"",
    ""unitPrice"",
    ""album"",
    ""genre"",
    ""mediaType"",
    ""invoiceItems"",
    ""playlistTrack""
  ]
}";
}