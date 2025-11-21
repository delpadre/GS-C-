using System;
using System.Collections.Generic;

namespace SkillSync.Domain.Entities;

public class Empresa
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
    public string Localizacao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public ICollection<Vaga> Vagas { get; set; } = new List<Vaga>();
}
