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
}