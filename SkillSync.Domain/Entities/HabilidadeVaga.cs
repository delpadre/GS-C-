using System;

namespace SkillSync.Domain.Entities;

public class HabilidadeVaga
{
    public Guid VagaId { get; set; }
    public Vaga Vaga { get; set; } = null!;

    public Guid HabilidadeId { get; set; }
    public Habilidade Habilidade { get; set; } = null!;
}
