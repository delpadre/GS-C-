using System;
using System.Collections.Generic;

namespace SkillSync.Domain.Entities;

public class Profissional
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Localizacao { get; set; } = string.Empty;
    public string ModalidadeTrabalho { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    // Nova propriedade para o controller
    public DateTime? DataAtualizacao { get; set; }

    // Propriedade de navegação obrigatória para EF
    public ICollection<HabilidadeProfissional> Habilidades { get; set; } = new List<HabilidadeProfissional>();
}
