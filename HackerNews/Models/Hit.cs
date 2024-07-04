using System.ComponentModel.DataAnnotations;

namespace HackerNews.Models;
public class Hit
{
    public string[] _tags { get; set; }
    public string Author { get; set; }
    public int Created_at_i { get; set; }
    public uint? Num_comments { get; set; }
    public string ObjectID { get; set; }
    public int? Parent_id { get; set; }
    public int? Points { get; set; }
    public int? Story_Id { get; set; }
    public string? Story_Title { get; set; }
    public Uri? Story_Url { get; set; }
    public string? Title { get; set; }
    public Uri? Url { get; set; }
    public string? Updated_At { get; set; }
}