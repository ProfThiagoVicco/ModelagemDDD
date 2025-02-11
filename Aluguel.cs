
public class Aluguel
{
    public Cliente Cliente { get; set; }
    public Carro Carro { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}