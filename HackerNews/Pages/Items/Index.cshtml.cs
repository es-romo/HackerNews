using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HackerNews.Models;
using HackerNews.Clients;

namespace HackerNews.Pages.Items;

public class IndexModel : PageModel
{
    public Item Item { get; set; } = default!;
	public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
			return NotFound();
		}
		else
		{
			Item = await V1Client.GetItemAsync((int)id);
		}
		return Page();
	}
}

