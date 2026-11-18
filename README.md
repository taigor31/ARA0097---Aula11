Projeto – ARA0097 (Aula 11): Gerência de Configuração e Git

Integrantes

TAIGOR DE JESUS SANTOS RODRIGUES 2026 0347 4437

Projeto ARA0097 – Gerência de Configuração e Git



### Diagrama de Casos de Uso (UML)
```mermaid
flowchart LR
    Provedor(["👤 Provedor ISP"])
    Vendedor(["👤 Vendedor"])

    subgraph Sistema ["Sistema de Vendas ISP"]
        UC01("UC01: Consultar Catálogo e Estoque")
        UC02("UC02: Cotar Equipamentos")
        UC03("UC03: Aplicar Desconto Atacado")
        UC04("UC04: Fechar Pedido de Venda")
        UC05("UC05: Notificar Estoque Insuficiente")
    end

    Provedor --> UC01
    Provedor --> UC02
    Vendedor --> UC02
    Vendedor --> UC04

    UC02 -.->|include| UC01
    UC03 -.->|extend: qtd >= 10| UC02
    UC04 -.->|include| UC01
    UC05 -.->|extend: sem saldo| UC04
