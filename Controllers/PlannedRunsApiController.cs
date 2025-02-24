using Microsoft.AspNetCore.Mvc;
using SampleCrudApp.Models;
using System.Linq;

[Route("api/plannedruns")]
[ApiController]
public class PlannedRunsApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlannedRunsApiController(AppDbContext context)
    {
        _context = context;
    }

    // Get all planned runs
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.PlannedRuns.ToList());
    }

    // Get a planned run by ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var run = _context.PlannedRuns.Find(id);
        if (run == null) return NotFound();
        return Ok(run);
    }

    // Create a new planned run
    [HttpPost]
    public IActionResult Create(PlannedRun plannedRun)
    {
        _context.PlannedRuns.Add(plannedRun);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = plannedRun.Id }, plannedRun);
    }

    // Update a planned run by ID
    [HttpPut("{id}")]
    public IActionResult Update(int id, PlannedRun updatedRun)
    {
        var existingRun = _context.PlannedRuns.Find(id);
        if (existingRun == null) return NotFound();

        existingRun.Date = updatedRun.Date;
        existingRun.Time = updatedRun.Time;
        existingRun.Distance = updatedRun.Distance;
        existingRun.RunType = updatedRun.RunType;
        existingRun.IsCompleted = updatedRun.IsCompleted;

        _context.SaveChanges();
        return NoContent();
    }

    // Delete a planned run by ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var run = _context.PlannedRuns.Find(id);
        if (run == null) return NotFound();

        _context.PlannedRuns.Remove(run);
        _context.SaveChanges();
        return NoContent();
    }

    // Mark a run as completed and move it to past runs
    [HttpPost("{id}/complete")]
    public IActionResult CompleteRun(int id)
    {
        var run = _context.PlannedRuns.Find(id);
        if (run == null) return NotFound();

        // Move to RunTracker (past runs)
        var completedRun = new RunTracker
        {
            Date = run.Date,
            Distance = run.Distance,
        };

        _context.RunTracker.Add(completedRun);
        _context.PlannedRuns.Remove(run);
        _context.SaveChanges();

        return Ok(completedRun);
    }
}
