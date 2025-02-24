using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleCrudApp.Models;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PlannedRun PlannedRun { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.PlannedRuns.Add(PlannedRun);
        _context.SaveChanges();

        return RedirectToPage("/PlannedRuns/Index"); // Redirect to planned runs list after adding
    }
}
