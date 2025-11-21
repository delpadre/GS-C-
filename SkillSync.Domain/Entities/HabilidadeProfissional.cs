namespace SkillSync.Domain.Entities;

public class HabilidadeProfissional
{
    public Guid ProfissionalId { get; set; }
    public Profissional Profissional { get; set; } = null!;

    public Guid HabilidadeId { get; set; }
    public Habilidade Habilidade { get; set; } = null!;
}
