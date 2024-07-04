using HackerNews.Models;

namespace HackerNews.Pages.Utils;

public static class Utils 
{
	public static string GetTimeAgoText(int Created_at_i)
	{
		DateTime createdAt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		createdAt = createdAt.AddSeconds(Created_at_i).ToLocalTime();
		TimeSpan diff = DateTime.UtcNow - createdAt;
		double diffMinutes = Math.Round(diff.TotalMinutes);
		double diffHours = Math.Round(diff.TotalHours);
		string timeAgoText = "";
		if (diffMinutes < 60)
		{
			timeAgoText = diffMinutes + (diffMinutes > 1 ? " minutes" : " minute");
		}
		else if (diffHours < 24)
		{
			timeAgoText = diffHours + (diffHours > 1 ? " hours" : "hour");
		}
		else
		{
			double diffDays = Math.Round(diffHours / 24);
			if (diffDays < 365)
			{
				timeAgoText = diffDays + (diffDays > 1 ? " days" : "day");
			}
			else
			{
				double diffYears = Math.Floor(diffDays / 365);
				timeAgoText = diffYears + (diffYears > 1 ? " years" : " year");
			}
		}
		return timeAgoText + " ago";
	}
}
