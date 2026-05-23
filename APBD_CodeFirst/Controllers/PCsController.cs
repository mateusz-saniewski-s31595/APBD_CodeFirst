using APBD_CodeFirst.DTOs;
using APBD_CodeFirst.Exceptions;
using APBD_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CodeFirst.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    private readonly IPCService _pcService;
    
    public PCsController(IPCService pcService)
    {
        _pcService = pcService;
    }

    //GET api/pcs
    [HttpGet]
    public async Task<IActionResult> GetAllPCs()
    {
        var pcs = await _pcService.GetAllPCs();
        return Ok(pcs);
    }
    
    //GET api/pcs/{id}/components
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCWithComponents(int id)
    {
        try
        {
            var pc = await _pcService.GetPCWithComponents(id);
            return Ok(pc);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
    //POST api/pcs
    [HttpPost]
    public async Task<IActionResult> PostPC([FromBody] PostPCDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var created = await _pcService.PostPC(dto);
            return CreatedAtAction(nameof(GetPCWithComponents), new { id = created.Id }, created);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    //PUT api/pcs/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPC(int id, [FromBody] PutPCDto dto)
    {
        try
        {
            await _pcService.PutPC(id, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }


    //DELETE api/pcs/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePC(int id)
    {
        try
        {
            await _pcService.DeletePC(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
}