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

### 🧑 **Cliente**
Representa o cliente que aluga um carro.

- `Id`: Identificador único do cliente.
- `Nome`: Nome do cliente.
- `Cpf`: Objeto de Valor (Value Object).

### 📅 **Aluguel** (Aggregate Root)
Gerencia a locação de um carro por um cliente.

- `Id`: Identificador único do aluguel.
- `Cliente`: Cliente que alugou o carro.
- `Carro`: Carro alugado.
- `DataInicio`: Data de início do aluguel.
- `DataFim`: Data de término do aluguel (opcional).
- `ValorTotal`: Valor total do aluguel.

---

## 🔗 **Objetos de Valor (Value Objects)**
- **`Cpf`**: Identificação única do cliente.
- **`Placa`**: Identificação única do carro.

---

## 🏗 **Agregados (Aggregates)**
- **Aluguel** é o **Aggregate Root**, pois gerencia a relação entre **Cliente** e **Carro**.
- A **consistência transacional** deve ser mantida dentro desse agregado.

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
