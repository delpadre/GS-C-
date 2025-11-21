using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Entities;

namespace SkillSync.Infrastructure.Data;

public class SkillSyncDbContext : DbContext
{
	public SkillSyncDbContext(DbContextOptions<SkillSyncDbContext> options) : base(options) { }

	// DbSets para cada entidade
	public DbSet<Profissional> Profissionais { get; set; }
	public DbSet<Habilidade> Habilidades { get; set; }
	public DbSet<Vaga> Vagas { get; set; }
	public DbSet<Empresa> Empresas { get; set; }
	public DbSet<TendenciaMercado> TendenciaMercados { get; set; }
	public DbSet<RecomendacaoCarreira> RecomendacaoCarreiras { get; set; }
	public DbSet<HabilidadeProfissional> HabilidadeProfissionais { get; set; }
	public DbSet<HabilidadeVaga> HabilidadeVagas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Configurações de chaves compostas para tabelas de junção
		modelBuilder.Entity<HabilidadeProfissional>()
			.HasKey(hp => new { hp.ProfissionalId, hp.HabilidadeId });

		modelBuilder.Entity<HabilidadeVaga>()
			.HasKey(hv => new { hv.VagaId, hv.HabilidadeId });

		// Configurações de relacionamentos
		modelBuilder.Entity<HabilidadeProfissional>()
			.HasOne(hp => hp.Profissional)
			.WithMany(p => p.Habilidades)
			.HasForeignKey(hp => hp.ProfissionalId);

		modelBuilder.Entity<HabilidadeProfissional>()
			.HasOne(hp => hp.Habilidade)
			.WithMany(h => h.Profissionais)
			.HasForeignKey(hp => hp.HabilidadeId);

		modelBuilder.Entity<HabilidadeVaga>()
			.HasOne(hv => hv.Vaga)
			.WithMany(v => v.Habilidades)
			.HasForeignKey(hv => hv.VagaId);

		modelBuilder.Entity<HabilidadeVaga>()
			.HasOne(hv => hv.Habilidade)
			.WithMany(h => h.Vagas)
			.HasForeignKey(hv => hv.HabilidadeId);

		// Configurações adicionais de índices
		modelBuilder.Entity<Profissional>()
			.HasIndex(p => p.Email)
			.IsUnique();

		modelBuilder.Entity<Empresa>()
			.HasIndex(e => e.CNPJ)
			.IsUnique();
	}
}