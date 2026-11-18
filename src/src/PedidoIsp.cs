using System;

public class PedidoIsp
{
    public string Equipamento { get; set; }
    public int Estoque { get; private set; }
    public decimal PrecoUnitario { get; set; }

    public PedidoIsp(string equipamento, int estoqueInicial, decimal precoUnitario)
    {
        Equipamento = equipamento;
        Estoque = estoqueInicial;
        PrecoUnitario = precoUnitario;
    }

    // RF01: 10% de desconto para 10 ou mais unidades
    public decimal CalcularTotal(int quantidade)
    {
        decimal total = quantidade * PrecoUnitario;
        if (quantidade >= 10)
            total *= 0.90m;

        return total;
    }

    // RF02: Valida e baixa o estoque
    public bool FecharPedido(int quantidade)
    {
        if (quantidade > Estoque)
            return false;

        Estoque -= quantidade;
        return true;
    }
}

class Program
{
    static void Main()
    {
        var onu = new PedidoIsp("ONU Wi-Fi 6", estoqueInicial: 20, precoUnitario: 200m);

        if (onu.CalcularTotal(10) != 1800m)
            throw new Exception("Erro no RF01: Desconto atacado incorreto.");

        if (!onu.FecharPedido(10) || onu.Estoque != 10)
            throw new Exception("Erro no RF02: Baixa de estoque incorreta.");

        Console.WriteLine("Todos os testes passaram com sucesso!");
    }
}
