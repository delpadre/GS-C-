using System;

namespace SkillSync.Domain.Entities;

public class RecomendacaoCarreira
{
    public Guid Id { get; set; }
    public Guid ProfissionalId { get; set; }
    public Profissional Profissional { get; set; } = null!;
    public string Texto { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
