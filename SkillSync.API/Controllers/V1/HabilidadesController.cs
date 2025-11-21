using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Entities;
using SkillSync.Infrastructure.Data;

namespace SkillSync.API.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
public class HabilidadesController : ControllerBase
{
	private readonly SkillSyncDbContext _context;
	private readonly ILogger<HabilidadesController> _logger;

	public HabilidadesController(SkillSyncDbContext context, ILogger<HabilidadesController> logger)
	{
		_context = context;
		_logger = logger;
	}

	// GET: api/v1/habilidades
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Habilidade>>> GetHabilidades()
	{
		var habilidades = await _context.Habilidades.ToListAsync();
		return Ok(habilidades);
	}

	// GET: api/v1/habilidades/{id}
	[HttpGet("{id}")]
	public async Task<ActionResult<Habilidade>> GetHabilidade(Guid id)
	{
		var habilidade = await _context.Habilidades.FindAsync(id);
		if (habilidade == null)
		{
			return NotFound();
		}
		return Ok(habilidade);
	}

	// POST: api/v1/habilidades
	[HttpPost]
	public async Task<ActionResult<Habilidade>> CreateHabilidade(Habilidade habilidade)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		habilidade.Id = Guid.NewGuid();
		habilidade.DataCriacao = DateTime.UtcNow;

		_context.Habilidades.Add(habilidade);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetHabilidade), new { id = habilidade.Id }, habilidade);
	}
}