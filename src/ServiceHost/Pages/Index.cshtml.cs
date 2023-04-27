using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ServiceHost.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProductCategoryApplication _productCategoryApplication;

    public IndexModel(ILogger<IndexModel> logger , IProductCategoryApplication productCategoryApplication)
    {
        _logger = logger;
        _productCategoryApplication = productCategoryApplication;
    }

    public async Task OnGet()
    {
    
    }
    
    public async Task<IActionResult> OnGetAjax()
    {
        var list = new List<List<string>>()
        {
            new List<string>()
            {
                "javascript",
                "script",
                "object oriented",
                "web client and server side",
                "1997"
            },
            new()
            {
                "java",
                "system",
                "object oriented",
                "server side",
                "standard"
            },
            new()
            {
                "java",
                "system",
                "object oriented",
                "server side",
                "standard"
            },
        };
        return  new JsonResult(list);
    }
}
