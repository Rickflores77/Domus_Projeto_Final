using Domus_Projeto.Models;
public class Morador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Apartamento { get; set; }
    public string Bloco { get; set; }

    public ICollection<Conta> Contas { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Mensagem> Mensagens { get; set; }
}