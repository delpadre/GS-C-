namespace SkillSync.Domain.Entities;

public class TendenciaMercado
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
