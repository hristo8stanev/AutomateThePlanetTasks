using Newtonsoft.Json;

namespace RestSharpProject.Models;
public class Album : IEquatable<Album>
{
    public Album() => Tracks = new HashSet<Tracks>();

    [JsonProperty(Required = Required.Always)]
    public long AlbumId { get; set; }
    [JsonProperty(Required = Required.AllowNull)]
    public string Title { get; set; }
    [JsonProperty(Required = Required.AllowNull)]
    public long ArtistId { get; set; }

    [JsonProperty(Required = Required.AllowNull)]
    public Artists Artist { get; set; }
    [JsonProperty(Required = Required.AllowNull)]
    public ICollection<Tracks> Tracks { get; set; }

    public bool Equals(Album other)
    {
        if (other == null)
        {
            return false;
        }
        return AlbumId.Equals(other.AlbumId);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Album);
    }
}
