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
        Documentary documentary = new Documentary(id, "Super Doc", "Ben Cross");
        
        return await Task.FromResult(Ok(documentary));
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        // Documentary documentary = new Documentary("1111-2222-3333-4444", "Super Doc", "Ben Cross");
        // List<Documentary> documentaries = new List<Documentary>([documentary]);

        var documentaries = await context.Documentaries.ToListAsync();
        
        return await Task.FromResult(Ok(documentaries));
    }
}