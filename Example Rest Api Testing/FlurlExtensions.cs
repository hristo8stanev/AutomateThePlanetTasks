using Flurl;

namespace Examples.Models;
// Ivaylo i made this extension method that will prevent url tracking
public static class FlurlExtensions
{
    public static Url AppendPathSegmentWithCheckup(this Url url, params string[] segments)
    {
        if (!url.Path.EndsWith(string.Join("/", segments)))
        {
            url.Reset();
            url.AppendPathSegments(segments);
        }

        return url;
    }
}
