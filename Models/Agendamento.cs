namespace BarbeariaProjeto.Models {
public class Agendamento {
    public int AgendamentoId { get; set; } 
    public string ?Nome { get; set; }    
    public string ?TipoDeCorte { get; set; }
    public string ?Data { get; set; }

    public ICollection<Barbeiro> Barbeiro { get; } = new List<Barbeiro>();
}
}