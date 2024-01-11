using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication9.Models;

namespace WebApplication9.Pages;

public class IndexModel : PageModel
{
    [BindProperty (SupportsGet = true)]
    public string answer { set; get; }
    [BindProperty (SupportsGet = true)]

    public string occasion { set; get; }
    [BindProperty (SupportsGet = true)]

    public string year { set; get; }
    [BindProperty (SupportsGet = true)]

    public string day { set; get; }

    
    private readonly ILogger<IndexModel> _logger;
    private readonly database db;
    public DataTable dt;
    public IndexModel(database db)
    {
        this.db = db;
    }

    public void OnGet()
    {
    }
    public void OnPostEvent(string occasion, int year,int month,int day)
    {
        
        Console.WriteLine(occasion);
        Console.WriteLine(month);
        Console.WriteLine(day);
        answer = db.AddEvent(occasion, year, month,day);
        Console.WriteLine(answer);
    }
}