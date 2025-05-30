using DocumentaryRestApi.DatabaseContext;
using DocumentaryRestApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentaryRestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController(DocumentaryContext context) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        // find the director by id
        var director = await context.Directors.FindAsync(id);
        if (director == null)
        {
            return NotFound();
        }
        
        return Ok(director);
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        // get all directors
        var directors = await context.Directors.ToListAsync();
        
        return Ok(directors);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Director director)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            context.Directors.Add(director);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, e);
        }
        
        // Generate the URL for the new resource using the route name
        string url = Url.RouteUrl("GetDirector", new { id = director.Id });
        
        return Created(url, director);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Director director)
    {
        if (id != director.Id)
        {
            return BadRequest();
        }
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        context.Entry(director).State = EntityState.Modified;
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Directors.Any(d => d.Id == id))
            {
                return NotFound();
            }
            throw;
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var director = await context.Directors.FindAsync(id);
        if (director == null)
        {
            return NotFound();
        }
        
        context.Directors.Remove(director);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}