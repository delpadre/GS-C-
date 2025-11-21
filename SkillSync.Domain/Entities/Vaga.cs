using System;
using System.Collections.Generic;

namespace SkillSync.Domain.Entities;

public class Vaga
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; } = null!;

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    // Navegação para HabilidadeVaga
    public ICollection<HabilidadeVaga> Habilidades { get; set; } = new List<HabilidadeVaga>();
}
