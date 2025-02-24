using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleCrudApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PlannedRunsModel : PageModel
{
    private readonly AppDbContext _context;

    public PlannedRunsModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PlannedRun PlannedRun { get; set; } = new PlannedRun { RunType = "Interval" };

    public List<PlannedRun> PlannedRuns { get; set; } = new List<PlannedRun>();

    public async Task<IActionResult> OnGetAsync()
    {
        PlannedRuns = await _context.PlannedRuns.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PlannedRuns = await _context.PlannedRuns.ToListAsync();
            return Page();
        }

        _context.PlannedRuns.Add(PlannedRun);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCompleteAsync(int id)
    {
        var run = await _context.PlannedRuns.FindAsync(id);
        if (run == null) return NotFound();

        run.IsCompleted = true;

        // Move completed run to RunTracker
        var completedRun = new RunTracker
        {
            Date = run.Date,
            Distance = run.Distance,
        };

        _context.RunTracker.Add(completedRun);
        _context.PlannedRuns.Remove(run);
        
        Console.WriteLine($"Run {run.Id} moved to RunTracker.");

        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}
