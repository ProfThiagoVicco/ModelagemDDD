# Modelo de Domínio - Sistema de Aluguel de Carros

## 📌 Introdução
Este documento descreve o modelo de domínio para um sistema de **aluguel de carros**, utilizando conceitos do **Design Tático no DDD**.

---

## 📂 **Entidades**
### 🚗 **Carro**
Representa um veículo disponível ou indisponível para aluguel.

- `Id`: Identificador único do carro.
- `Modelo`: Modelo do carro.
- `Placa`: Objeto de Valor (Value Object).
- `Disponivel`: Indica se o carro está disponível para aluguel.

```csharp
public class Carro
{
    public Guid Id { get; private set; }
    public string Modelo { get; private set; }
    public Placa Placa { get; private set; }
    public bool Disponivel { get; private set; }

    public Carro(string modelo, Placa placa)
    {
        Id = Guid.NewGuid();
        Modelo = modelo;
        Placa = placa;
        Disponivel = true;
    }

    public void MarcarIndisponivel() => Disponivel = false;
    public void MarcarDisponivel() => Disponivel = true;
}
```

### 🧑 **Cliente**
Representa o cliente que aluga um carro.

- `Id`: Identificador único do cliente.
- `Nome`: Nome do cliente.
- `Cpf`: Objeto de Valor (Value Object).

```csharp
public class Cliente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Cpf Cpf { get; private set; }

    public Cliente(string nome, Cpf cpf)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cpf = cpf;
    }
}
```

### 📅 **Aluguel** (Aggregate Root)
Gerencia a locação de um carro por um cliente.

- `Id`: Identificador único do aluguel.
- `Cliente`: Cliente que alugou o carro.
- `Carro`: Carro alugado.
- `DataInicio`: Data de início do aluguel.
- `DataFim`: Data de término do aluguel (opcional).
- `ValorTotal`: Valor total do aluguel.

```csharp
public class Aluguel
{
    public Guid Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public Carro Carro { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime? DataFim { get; private set; }
    public decimal ValorTotal { get; private set; }

    public Aluguel(Cliente cliente, Carro carro, DateTime dataInicio)
    {
        Id = Guid.NewGuid();
        Cliente = cliente;
        Carro = carro;
        DataInicio = dataInicio;
        Carro.MarcarIndisponivel();
    }

    public void FinalizarAluguel(DateTime dataFim, decimal valorTotal)
    {
        DataFim = dataFim;
        ValorTotal = valorTotal;
        Carro.MarcarDisponivel();
    }
}
```

---

## 🔗 **Objetos de Valor (Value Objects)**
- **`Cpf`**: Identificação única do cliente.
- **`Placa`**: Identificação única do carro.

```csharp
public class Cpf
{
    public string Numero { get; private set; }

    public Cpf(string numero)
    {
        if (!Regex.IsMatch(numero, "^[0-9]{11}$"))
            throw new ArgumentException("CPF inválido!");
        Numero = numero;
    }
}

public class Placa
{
    public string Numero { get; private set; }

    public Placa(string numero)
    {
        if (!Regex.IsMatch(numero, "^[A-Z]{3}-[0-9]{4}$"))
            throw new ArgumentException("Placa inválida!");
        Numero = numero;
    }
}
```

---

## 🏗 **Agregados (Aggregates)**
- **Aluguel** é o **Aggregate Root**, pois gerencia a relação entre **Cliente** e **Carro**.
- A **consistência transacional** deve ser mantida dentro desse agregado.

```csharp
public interface IAluguelRepository
{
    Aluguel ObterPorId(Guid id);
    void Salvar(Aluguel aluguel);
}
```

---

## 🗃 **Repositórios (Repositories)**
Os repositórios encapsulam a lógica de persistência.

- `IAluguelRepository`: Interface para salvar e recuperar aluguéis.
- Exemplo:
  ```csharp
  public interface IAluguelRepository
  {
      Aluguel ObterPorId(Guid id);
      void Salvar(Aluguel aluguel);
  }
  ```

---
