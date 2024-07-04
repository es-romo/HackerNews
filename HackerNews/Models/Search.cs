namespace HackerNews.Models;
public class Search
{
    public Hit[] Hits { get; set; }
    public uint HitsPerPage { get; set; }
    public uint NbHits { get; set; }
    public uint NbPages { get; set; }
    public uint Page { get; set; }
}
