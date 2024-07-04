using System.ComponentModel.DataAnnotations;

namespace HackerNews.Models;

public class Item
{
	public string Author { get; set; }
	public Item[]? Children { get; set; }
	public int Created_at_i { get; set; }
	public int Id { get; set; }
	public int[] Options { get; set; }
	public int? Points { get; set; }
	public int? Story_id { get; set; }
	public string? Text { get; set; }
	public string? Title { get; set; }
	// story, poll, pollopt
	public string Type { get; set; }
	public Uri? Url { get; set; }
}

