using Microsoft.AspNetCore.Mvc;
using SampleCrudApp.Models;
using System.Linq;

public class RunTrackerController : Controller
{
    private readonly AppDbContext _context;

    public RunTrackerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var runs = _context.RunTracker.ToList(); 
        return View(runs); 
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RunTracker runTracker)
    {
        if (ModelState.IsValid)
        {
            _context.RunTracker.Add(runTracker); // Use RunTracker here
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(runTracker);
    }

    public IActionResult Edit(int id)
    {
        var runTracker = _context.RunTracker.Find(id); // Use RunTracker here
        if (runTracker == null)
        {
            return NotFound();
        }
        return View(runTracker);
    }

    [HttpPost]
    public IActionResult Edit(RunTracker runTracker)
    {
        if (ModelState.IsValid)
        {
            _context.RunTracker.Update(runTracker); // Use RunTracker here
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(runTracker);
    }

    public IActionResult Chart()
{
    var runs = _context.RunTracker.ToList();
    return View(runs); // Pass the runs data to the Chart.cshtml view
}
    public IActionResult Delete(int id)
    {
        var runTracker = _context.RunTracker.Find(id);
        if (runTracker == null)
        {
            return NotFound();
        }
        return View(runTracker);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var runTracker = _context.RunTracker.Find(id); // Find the record
        if (runTracker == null)
    {
        return NotFound(); // If the record is not found, return a 404
    }

    _context.RunTracker.Remove(runTracker); // Delete the record
    _context.SaveChanges(); // Save changes to the database
    return RedirectToAction(nameof(Index)); // Redirect back to Index page
}
}
