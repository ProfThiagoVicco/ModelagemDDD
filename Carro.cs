public class Carro
{
    public Guid Id { get; private set; }
    public string Modelo { get; private set; }
    public Placa Placa { get; private set; } // Value Object
    public bool Disponivel { get; private set; }

    public Carro(string modelo, Placa placa)
    {
        Id = Guid.NewGuid();
        Modelo = modelo;
        Placa = placa;
        Disponivel = true;
    }

    public void MarcarIndisponivel()
    {
        Disponivel = false;
    }

    public void MarcarDisponivel()
    {
        Disponivel = true;
    }
}