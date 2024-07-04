using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HackerNews.Models;

namespace HackerNews.Clients;



public class V1Client
{
    public enum SearchType
    {
        ByRelevance,
        ByDate,
    }
    static string Url = "http://hn.algolia.com/api/v1/";
	static HttpClient client = new HttpClient();
	public static uint hitsPerPage = 30;

    public static async Task<Item> GetItemAsync(int id)
	{
		Item item = null;
		HttpResponseMessage response = await client.GetAsync(Url + "items/"+id);
		if (response.IsSuccessStatusCode)
		{
			item = await response.Content.ReadFromJsonAsync<Item>();
		}
		return item;
	}

    public static async Task<Search> GetSearchAsync(SearchType type)
	{
		return await GetSearchAsync(type, new Dictionary<string, string>());

    }

    public static async Task<Search> GetSearchAsync(SearchType type, Dictionary<string,string> queryParams)
	{
		HttpContent content = new FormUrlEncodedContent(queryParams);
        string query = await content.ReadAsStringAsync();
		string search = type == SearchType.ByRelevance ? "search" : "search_by_date";
        HttpResponseMessage response = await client.GetAsync(Url + search + "?" + query);
		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<Search>();
		}
		return null;
    }

    public static async Task<Search> GetNewest(int p = 0)
    {
        Dictionary<string, string> queryParams = new Dictionary<string, string>();

        queryParams.Add("page", p.ToString());
        queryParams.Add("hitsPerPage", hitsPerPage.ToString());
        queryParams.Add("tags", "(story,poll)");

        return await GetSearchAsync(SearchType.ByDate, queryParams);
    }

    public static async Task<Search> GetFrontPage(int p = 0)
	{
        Dictionary<string, string> queryParams = new Dictionary<string, string>();

		queryParams.Add("page", p.ToString());
		queryParams.Add("hitsPerPage", hitsPerPage.ToString());
        queryParams.Add("tags", "front_page");

        return await GetSearchAsync(SearchType.ByRelevance, queryParams);
	}

    public static async Task<Search> GetRelevantRecent(int? p = 0)
    {
        Dictionary<string, string> queryParams = new Dictionary<string, string>();
        DateTimeOffset now = DateTimeOffset.UtcNow;
        DateTimeOffset before = now.AddDays(-2);
        before.AddHours(-before.Hour);
        before.AddMinutes(-before.Minute);
        before.AddSeconds(-before.Second);

        queryParams.Add("page", p.ToString());
        queryParams.Add("hitsPerPage", hitsPerPage.ToString());
        queryParams.Add("tags", "(story,poll)");
        queryParams.Add("numericFilters", "created_at_i>"+ before.ToUnixTimeSeconds() + ",created_at_i<"+ now.ToUnixTimeSeconds());

        return await GetSearchAsync(SearchType.ByRelevance, queryParams);
    }

}
