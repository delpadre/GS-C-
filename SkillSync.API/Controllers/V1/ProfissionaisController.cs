using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Entities;
using SkillSync.Infrastructure.Data;

namespace SkillSync.API.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
public class ProfissionaisController : ControllerBase
{
    private readonly SkillSyncDbContext _context;
    private readonly ILogger<ProfissionaisController> _logger;

    public ProfissionaisController(SkillSyncDbContext context, ILogger<ProfissionaisController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/v1/profissionais
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profissional>>> GetProfissionais()
    {
        try
        {
            var profissionais = await _context.Profissionais.ToListAsync();
            return Ok(profissionais);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar profissionais");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    // GET: api/v1/profissionais/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Profissional>> GetProfissional(Guid id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        if (profissional == null)
        {
            return NotFound();
        }
        return Ok(profissional);
    }

    // POST: api/v1/profissionais
    [HttpPost]
    public async Task<ActionResult<Profissional>> CreateProfissional(Profissional profissional)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            profissional.Id = Guid.NewGuid();
            profissional.DataCriacao = DateTime.UtcNow;

            _context.Profissionais.Add(profissional);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfissional), new { id = profissional.Id }, profissional);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar profissional");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    // PUT: api/v1/profissionais/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfissional(Guid id, Profissional profissional)
    {
        if (id != profissional.Id)
        {
            return BadRequest();
        }

        _context.Entry(profissional).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProfissionalExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/v1/profissionais/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfissional(Guid id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        if (profissional == null)
        {
            return NotFound();
        }

        _context.Profissionais.Remove(profissional);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProfissionalExists(Guid id)
    {
        return _context.Profissionais.Any(e => e.Id == id);
    }
}