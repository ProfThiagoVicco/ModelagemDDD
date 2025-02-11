public class Aluguel2
{
    public Guid Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public Carro Carro { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime? DataFim { get; private set; }
    public decimal ValorTotal { get; private set; }

    public Aluguel2(Cliente cliente, Carro carro, DateTime dataInicio)
    {
        if (carro == null || !carro.Disponivel)
            throw new InvalidOperationException("Carro não disponível para aluguel.");

        Id = Guid.NewGuid();
        Cliente = cliente;
        Carro = carro;
        DataInicio = dataInicio;
        Carro.MarcarIndisponivel();
    }

    public void FinalizarAluguel(DateTime dataFim)
    {
        if (DataFim != null)
            throw new InvalidOperationException("O aluguel já foi finalizado.");

        DataFim = dataFim;
        ValorTotal = CalcularValorTotal();
        Carro.MarcarDisponivel();
    }

    private decimal CalcularValorTotal()
    {
        var dias = (DataFim - DataInicio)?.Days ?? 1;
        return dias * 100m; // Preço fixo de R$100 por dia
    }
}