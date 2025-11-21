using System;
using System.Collections.Generic;

namespace SkillSync.Domain.Entities;

public class Habilidade
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    // ? Coleções de navegação
    public ICollection<HabilidadeProfissional> Profissionais { get; set; } = new List<HabilidadeProfissional>();
    public ICollection<HabilidadeVaga> Vagas { get; set; } = new List<HabilidadeVaga>();
}
