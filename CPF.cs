public class Cpf
{
    public string Numero { get; private set; }

    public Cpf(string numero)
    {
        if (!ValidarCpf(numero))
            throw new ArgumentException("CPF inválido!");

        Numero = numero;
    }

    private bool ValidarCpf(string numero)
    {
        throw new NotImplementedException();
    }
}