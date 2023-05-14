using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public async Task<VirtualFileResult> OnGet()
        {
            var result = await Task.FromResult(File("~/index.html", "text/html"));
            return result;
        }
    }
}
