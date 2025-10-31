public class Votacao
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataFim { get; set; }
    public bool Encerrada { get; set; }
    public int Participacao { get; set; }
    public int TotalVotos { get; set; }
}