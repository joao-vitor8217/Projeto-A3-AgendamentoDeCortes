using System.Text.Json.Serialization;
namespace BarbeariaProjeto.Models;

public class Barbeiro {
    public int BarbeiroId { get; set; }
    public string ?BarbeiroNome { get; set; }
    public int AgendamentoId { get; set; }
    [JsonIgnore]

    public Agendamento Agendamento { get; set; } = null!;
}