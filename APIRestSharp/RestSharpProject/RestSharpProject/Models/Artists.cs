namespace RestSharpProject.Models;
public class Artists
{
    public Artists() => Albums = new HashSet<Album>();

    public long ArtistId { get; set; }
    public string Name { get; set; }

    public ICollection<Album> Albums { get; set; }
}
