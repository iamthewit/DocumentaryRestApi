using DocumentaryRestApi.DatabaseContext;
using DocumentaryRestApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentaryRestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentaryController(DocumentaryContext context) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var documentary = await context.Documentaries.FindAsync(id);

        if (documentary == null)
        {
            return NotFound();
        }

        return Ok(documentary);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var documentaries = await context.Documentaries.ToListAsync();
        
        return await Task.FromResult(Ok(documentaries));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Documentary documentary)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            context.Documentaries.Add(documentary);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, e);
        }
        
        // Generate the URL for the new resource using the route name
        string url = Url.RouteUrl("GetDocumentary", new { id = documentary.Id });
        
        return Created(url, documentary);
    }
}